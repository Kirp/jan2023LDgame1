using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

    [SerializeField]
    private Image splashSign;

    private Vector2 defaultSplashPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        defaultSplashPosition = splashSign.rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void warnOfSplash()
    {

        StartCoroutine(SplashWarn());
    }

    IEnumerator SplashWarn()
    {
        float testval = 0;
        float runTime = 1;
        Debug.Log(defaultSplashPosition);
        splashSign.rectTransform.anchoredPosition = defaultSplashPosition;

        
        while (testval < runTime)
        {
            if(testval < runTime/2)
            {
                splashSign.rectTransform.anchoredPosition = new Vector2(defaultSplashPosition.x, defaultSplashPosition.y+10);
            }else
            {
                
                splashSign.rectTransform.anchoredPosition = new Vector2(defaultSplashPosition.x, defaultSplashPosition.y-10);
            }


            //Debug.Log("count down: "+testval);
            testval+=Time.deltaTime;

            float testToAlp = testval / runTime;
            //Debug.Log("test to alp: "+testToAlp);
            
            splashSign.color= new Color32(255, 255, 255, (byte) (255- (255 * testToAlp)));
            

            yield return null;
        }

        yield return new WaitForSeconds(3f);
        Debug.Log("done");

    }
}
