using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    
    public void PlayGame () {
        GameManager.score = 0;
        GlobalAchievements.ach10Count = 0;
        GameManager.lives = 3;
        GameManager.doublePointsActive = false;
        Player.thrustSpeed = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void Options () {
        SceneManager.LoadScene(2);
    }

    public void MainMenu () {
        SceneManager.LoadScene(0);
    }

    public void HowToPlayMenu () {
        SceneManager.LoadScene(4);
    }

    public void SetVolume(float volume) {
        BackgroundMusic._audioSource.volume = volume;
        Debug.Log(volume);
    }

    public void SetQuality (int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ExitGame() {
        Debug.Log ("EXIT");
        Application.Quit();
    }
}
