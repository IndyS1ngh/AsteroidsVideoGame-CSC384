using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameUI : MonoBehaviour
{
    
    public Text scoreText;
    public Text livesText;

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = GameManager.score.ToString();
        //livesText.GetComponent<Text>().text = GlobalAchievements.ach10Count.ToString();
        livesText.GetComponent<Text>().text = GameManager.lives.ToString();
    }
}
