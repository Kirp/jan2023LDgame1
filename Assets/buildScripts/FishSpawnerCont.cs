using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerCont : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;

    [SerializeField] private CanvasControl canvasControl;


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
            timePerRelease = Random.Range(2f, 4f);
            canvasControl.warnOfSplash();
            //Instantiate(fishPrefab, transform.position, Quaternion.identity);
            StartCoroutine(FishSpawn());
        }
    }

    IEnumerator FishSpawn()
    {
        yield return new WaitForSeconds(1f);

        int fishSpawn = Random.Range(1, 4);
        Vector2 spawnPoint = transform.position;
        for (var i = 0; i < fishSpawn; i++)
        {
            spawnPoint.x -= (0.45f * i);
            Instantiate(fishPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
