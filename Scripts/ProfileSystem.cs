using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProfileSystem : MonoBehaviour
{
    public Text prof1Score;
    public Text prof1Lives;
    public Text prof1Achs;
    public Text prof1Boss;
    public Text prof2Score;
    public Text prof2Lives;
    public Text prof2Achs;
    public Text prof2Boss;
    public Text prof3Score;
    public Text prof3Lives;
    public Text prof3Achs;
    public Text prof3Boss;
    public int scorePlaceholder = 0;
    public int livesPlaceholder = 3;
    public int achsPlaceholder = 0;
    public bool bossPlaceholder = false;
    public static GameData data1;
    public static GameData data2;
    public static GameData data3;
    
    //could be awake, start for additional stuff
    void Start() {
        data1 = SaveSystem.LoadGame1();
        data2 = SaveSystem.LoadGame2();
        data3 = SaveSystem.LoadGame3();
        if (data1 == null || data2 == null || data3 == null) {
            Debug.LogError("Save data missing!");
        }
    }

    void Update() {
        if (data1 != null) {
            prof1Score.GetComponent<Text>().text = data1.score.ToString();
            prof1Lives.GetComponent<Text>().text = data1.lives.ToString();
            prof1Achs.GetComponent<Text>().text = data1.achievementsGot.ToString();
            prof1Boss.GetComponent<Text>().text = data1.bossDead.ToString();
        } else {
            prof1Score.GetComponent<Text>().text = scorePlaceholder.ToString();
            prof1Lives.GetComponent<Text>().text = livesPlaceholder.ToString();
            prof1Achs.GetComponent<Text>().text = achsPlaceholder.ToString();
            prof1Boss.GetComponent<Text>().text = bossPlaceholder.ToString();
        }
        if (data2 != null) {
            prof2Score.GetComponent<Text>().text = data2.score.ToString();
            prof2Lives.GetComponent<Text>().text = data2.lives.ToString();
            prof2Achs.GetComponent<Text>().text = data2.achievementsGot.ToString();
            prof2Boss.GetComponent<Text>().text = data2.bossDead.ToString();
        } else {
            prof2Score.GetComponent<Text>().text = scorePlaceholder.ToString();
            prof2Lives.GetComponent<Text>().text = livesPlaceholder.ToString();
            prof2Achs.GetComponent<Text>().text = achsPlaceholder.ToString();
            prof2Boss.GetComponent<Text>().text = bossPlaceholder.ToString();
        }
        if (data3 != null) {
            prof3Score.GetComponent<Text>().text = data3.score.ToString();
            prof3Lives.GetComponent<Text>().text = data3.lives.ToString();
            prof3Achs.GetComponent<Text>().text = data3.achievementsGot.ToString();
            prof3Boss.GetComponent<Text>().text = data3.bossDead.ToString();
        } else {
            prof3Score.GetComponent<Text>().text = scorePlaceholder.ToString();
            prof3Lives.GetComponent<Text>().text = livesPlaceholder.ToString();
            prof3Achs.GetComponent<Text>().text = achsPlaceholder.ToString();
            prof3Boss.GetComponent<Text>().text = bossPlaceholder.ToString();
        }
    }
}
