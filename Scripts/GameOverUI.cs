using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOverUI : MonoBehaviour
{
    
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = GameManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.GetComponent<Text>().text = GameManager.score.ToString();
    }
}