using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    private GameObject fishTossFab;

    [SerializeField]
    private GameObject tossPoint;

    [SerializeField]
    private GameObject powerBar;

    private PowerBarCont powerBarScript;

    private Rigidbody2D rb2d;
    private float sideMovement = 0;
    private float runSpeed = 5f;

    private bool jumpCommand = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sideMovement = 0;
    }

    private void Awake()
    {
        powerBarScript = powerBar.GetComponent<PowerBarCont>();
    }

    // Update is called once per frame
    void Update()
    {
        sideMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jumpCommand = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            powerBar.SetActive(true);
            powerBarScript.StartMeter();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            float powerResult = powerBarScript.StopMeter();
            Debug.Log("fire!");
            powerBar.SetActive(false);
            //TossFish(1, powerResult>0.4f?powerResult:0.4f);

            CircleCollider2D myCollider = GetComponent<CircleCollider2D>();
            myCollider.enabled = false;
            Collider2D[] victim = Physics2D.OverlapCircleAll(transform.position, 1.5f, (1<<7));
            myCollider.enabled = true;

            //Debug.Log("attack hits: "+victim.Length);
            if (victim.Length>0)
            {
                Debug.Log(victim);
                foreach(Collider2D pish in victim)
                {
                    Destroy(pish.gameObject);
                    TossFish(1, powerResult>0.4f?powerResult:0.4f);
                }
            }


        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, 1.5f);
    }

    private void TossFish(int fishCatchNum, float power)
    {
        for (var i = 0; i < fishCatchNum; i++)
        {
            GameObject toss = Instantiate(fishTossFab, tossPoint.transform.position, Quaternion.identity);
            toss.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.75f - (1f * power), 5f*power), ForceMode2D.Impulse);
            toss.GetComponent<Rigidbody2D>().AddTorque(700f*power);
        }
    }

    //dont forget the physics should be updated here
    private void FixedUpdate()
    {
        

        if (jumpCommand)
        {

        }

        rb2d.velocity = new Vector2(sideMovement * runSpeed, rb2d.velocity.y);
    }
}
