using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{
    public Button backButton;
    public AudioMixer audioMixer;
    
    public void MainMenu () {
        SceneManager.LoadScene(0);
    }

}
