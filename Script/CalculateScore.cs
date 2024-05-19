using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CalculateScore : MonoBehaviour
{
    private GameManager gameManager;
    public TMP_Text totalScoreText, rankText;
    private int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        totalScoreText.text = gameManager.scoreText.text;
        
    }

    // Update is called once per frame
    void Update()
    { 
        totalScore = int.Parse(totalScoreText.text);
            if(totalScore > 300){
                rankText.text = "S";
            } else if(totalScore > 250){
                rankText.text = "A";
            } else if(totalScore > 200){
                rankText.text = "B";
            } else if(totalScore > 150){
                rankText.text = "C";
            } else if(totalScore > 100){
                rankText.text = "D";
            } else if(totalScore > 50){
                rankText.text = "E";
            } else {
                rankText.text = "F";
            }
    }
}
