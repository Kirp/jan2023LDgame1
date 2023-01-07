using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInWaterCont : MonoBehaviour
{

    private float swimSpeed = 8f;

    private void Update()
    {
        transform.Translate(Vector2.right* swimSpeed * Time.deltaTime);

        if(transform.position.x > 18f)
        {
            Destroy(gameObject);
        }
    }



}
