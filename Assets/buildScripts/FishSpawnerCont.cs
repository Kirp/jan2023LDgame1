using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerCont : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;


    private float timePerRelease = 2f;
    private float timeLapsed = 0;

    private bool spawnTimeStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        spawnTimeStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeLapsed += Time.deltaTime;
        if (timeLapsed > timePerRelease)
        {
            timeLapsed = 0;

            Instantiate(fishPrefab, transform.position, Quaternion.identity);

        }
    }
}
