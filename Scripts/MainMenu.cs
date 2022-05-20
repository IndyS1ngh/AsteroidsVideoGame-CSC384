using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () {
        GameManager.score = 0;
        GlobalAchievements.ach10Count = 0;
        GameManager.lives = 3;
        GameManager.doublePointsActive = false;
        Player.thrustSpeed = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void HowToPlayMenu () {
        SceneManager.LoadScene(4);
    }
    
    public void Options () {
        SceneManager.LoadScene(2);
    }

    public void ProfileSelect () {
        SceneManager.LoadScene(5);
    }

    public void ExitGame() {
        Debug.Log ("EXIT");
        Application.Quit();
    }
}
