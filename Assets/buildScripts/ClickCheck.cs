using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickCheck : MonoBehaviour
{
    public void ClickStart()
    {
        Debug.Log("Start the game!");
        SceneManager.LoadScene(1);
    }   
}
