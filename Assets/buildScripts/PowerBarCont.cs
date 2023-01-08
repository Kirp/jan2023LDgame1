using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarCont : MonoBehaviour
{

    [SerializeField] private GameObject powerPointer;

    private bool meterMove = false;
    private float meterSpeed = 1f;

    private bool movingUp = true;

    private Vector2 startUpPosition = new Vector2(0, -0.45f);


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartMeter()
    {
        powerPointer.transform.localPosition = startUpPosition;
        meterMove = true;
    }

    public float StopMeter()
    {
        meterMove = false;
        float stopPosition = powerPointer.transform.localPosition.y;
        return (stopPosition + 0.45f) / 0.9f;

    }
    

    // Update is called once per frame
    void Update()
    {
        if (meterMove)
        {

            if (movingUp)
            {
                powerPointer.transform.Translate(Vector2.up *meterSpeed *Time.deltaTime);
                if (powerPointer.transform.localPosition.y > 0.45) movingUp = false;
            }else
            {
                powerPointer.transform.Translate(Vector2.up * -meterSpeed * Time.deltaTime);
                if (powerPointer.transform.localPosition.y < -0.45) movingUp = true;
            }


        }
    }
}
