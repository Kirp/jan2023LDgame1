using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossFishCont : MonoBehaviour
{
    private void Awake()
    {
        Invoke("ActivateCollider", 0.25f);
    }

    private void ActivateCollider()
    {
        GetComponent<CapsuleCollider2D>().enabled = true;
    }

    private void Update()
    {
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
        }
    }
}
