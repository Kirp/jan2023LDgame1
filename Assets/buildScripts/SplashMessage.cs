using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashMessage : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer srend;

    [SerializeField]
    private bool tester = false;

    // Start is called before the first frame update
    void Start()
    {
        srend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tester)
        {

        }
    }

}
