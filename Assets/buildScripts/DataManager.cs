using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DataManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text stomachText;
    [SerializeField] TMP_Text winloseText;

    [SerializeField] Button restartButton;

    [SerializeField] GameObject spawner;

    private int totalScore = 0;
    private float foodInStomach = 31;
    private float maxFoodInStomach = 100;
    private float hungerDrain = 1f;

    public bool gameover = false;

    public void AteSomething(int foodType = 1)
    {
        if(foodInStomach<maxFoodInStomach) foodInStomach += 5;
        totalScore += 10;
    }

    public void MaxWhappedAThing(int whappedCount = 1)
    {
        totalScore += 50 * whappedCount;
    }

    private void Awake()
    {
        StartCoroutine(HungerEffect());
    }

    IEnumerator HungerEffect()
    {
        foodInStomach -= hungerDrain;
        yield return new WaitForSeconds(1);

        if (!gameover) StartCoroutine(HungerEffect());

    }

    private void Update()
    {
        float stom = (foodInStomach / maxFoodInStomach)*100;
        //Debug.Log("Stom:"+stom);
        //update the gui
        ScoreText.text = "Score: " + totalScore;
        stomachText.text = "Stomach: " + stom + "%";

        if(stom <= 0)
        {
            //gameover lose
            winloseText.text = "Game Over!";
            GameOver();
        }

        if(stom>=100)
        {
            //gameover win
            winloseText.text = "Game Over! You Win!";
            GameOver();
        }

    }

    private void GameOver()
    {
        spawner.SetActive(false);
        winloseText.enabled = true;
        restartButton.gameObject.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
