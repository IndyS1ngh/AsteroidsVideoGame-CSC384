using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GlobalAchievements : MonoBehaviour
{   
    public static GlobalAchievements Instance;
    public Queue<IEnumerator> achievementQueue = new Queue<IEnumerator>();
    public event EventHandler test;
    
    void Awake() {
        if (Instance) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    //General Variables
    public GameObject achNote;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;
    public bool coroutineTriggered = false;
    public static int achievementsEarned = 0;
    public static bool achievement1Got = false;
    public static bool achievement2Got = false;
    public static bool achievement3Got = false;
    public static bool achievement4Got = false;
    public static bool achievement5Got = false;
    public static bool achievement6Got = false;
    public static bool achievement7Got = false;
    public static bool achievement8Got = false;
    public static bool achievement9Got = false;
    public static bool achievement10Got = false;
    public static bool achievement11Got = false;
    public static bool achievement12Got = false;
    public static bool achievement13Got = false;
    public static bool achievement14Got = false;

    //POTION TYPE COLLECTION
    
    //DoublePoints Specific
    public static int ach01Count;
    public int ach01Trigger = 1;
    public static int ach01Code;
    public static int ach01ID = 1;

    public int ach05Trigger = 5;
    public static int ach05Code;
    public static int ach05ID = 5;

    //ExtraLife Specific
    public static int ach02Count;
    public int ach02Trigger = 1;
    public static int ach02Code;
    public static int ach02ID = 2;

    public int ach06Trigger = 5;
    public static int ach06Code;
    public static int ach06ID = 6;

    //ScreenNuke Specific
    public static int ach03Count;
    public int ach03Trigger = 1;
    public static int ach03Code;
    public static int ach03ID = 3;

    public int ach07Trigger = 5;
    public static int ach07Code;
    public static int ach07ID = 7;

    //SpeedBoost Specific
    public static int ach04Count;
    public int ach04Trigger = 1;
    public static int ach04Code;
    public static int ach04ID = 4;

    public int ach08Trigger = 5;
    public static int ach08Code;
    public static int ach08ID = 8;

    //Invincibility specific
    public static int ach13Count;
    public int ach13Trigger = 1;
    public static int ach13Code;
    public static int ach13ID = 13;

    public int ach14Trigger = 5;
    public static int ach14Code;
    public static int ach14ID = 14;

    //ASTEROIDS KILLED
    //10 Asteroids
    public static int ach09Count = 0;
    public int ach09Trigger = 10;
    public static int ach09Code;
    public static int ach09ID = 9;

    public int ach11Trigger = 50;
    public static int ach11Code;
    public static int ach11ID = 11;

    //HIGH SCORE
    //3000 Points
    public static int ach10Count;
    public int ach10Trigger = 3000;
    public static int ach10Code;
    public static int ach10ID = 10;

    public int ach12Trigger = 10000;
    public static int ach12Code;
    public static int ach12ID = 12;
    //if code = ID then achievement earnt 
    
    void Start() {
        StartCoroutine("AchievementQueueCheck");
    }

    IEnumerator AchievementQueueCheck() {
        for(; ;) {
            if (achievementQueue.Count > 0 && coroutineTriggered == false) StartCoroutine(achievementQueue.Dequeue());
            yield return new WaitForSeconds(0f);
        }
    }

    //listening for event in doublepoints
    public void subscribeToDoublePointsTrigger(DoublePointsTrigger script) {
        script.pickupDoublePoints += doublePointsPickup;
    }

    private void doublePointsPickup(object sender, System.EventArgs e) {
        ach01Count += 1;
        // if statement checking here
        if (ach01Count == ach01Trigger && ach01Code != 1 && achievement1Got == false) {
            achievement1Got = true;
            achievementQueue.Enqueue(Trigger01Ach());
            //StartCoroutine(Trigger01Ach());
        }
        if (ach01Count == ach05Trigger && ach05Code != 5 && achievement5Got == false) {
            //StartCoroutine(Trigger05Ach());
            achievement5Got = true;
            achievementQueue.Enqueue(Trigger05Ach());
        }
    }

    //listening for event in extra life
    public void subscribeToExtraLifeTrigger(ExtraLifeTrigger script) {
        script.pickupExtraLife += extraLifePickup;
    }
    
    private void extraLifePickup(object sender, System.EventArgs e) {
        ach02Count += 1;
        if (ach02Count == ach02Trigger && ach02Code != 2 && achievement2Got == false) {
            //StartCoroutine(Trigger02Ach());
            achievement2Got = true;
            achievementQueue.Enqueue(Trigger02Ach());
        }
        if (ach02Count == ach06Trigger && ach06Code != 6 && achievement6Got == false) {
            //StartCoroutine(Trigger06Ach());
            achievement6Got = true;
            achievementQueue.Enqueue(Trigger06Ach());
        }
    }

    public void subscribeToScreenNukeTrigger(ScreenNukeTrigger script) {
        script.pickupScreenNuke += screenNukePickup;
    }
    
    private void screenNukePickup(object sender, System.EventArgs e) {
        ach03Count += 1;
        if (ach03Count == ach03Trigger && ach03Code != 3 && achievement3Got == false) {
            //StartCoroutine(Trigger03Ach());
            achievement3Got = true;
            achievementQueue.Enqueue(Trigger03Ach());
        }
        if (ach03Count == ach07Trigger && ach07Code != 7 && achievement7Got == false) {
            //StartCoroutine(Trigger07Ach());
            achievement7Got = true;
            achievementQueue.Enqueue(Trigger07Ach());
        }
    }

    public void subscribeToSpeedBoostTrigger(SpeedBoostTrigger script) {
        script.pickupSpeedBoost += speedBoostPickup;
    }
    
    private void speedBoostPickup(object sender, System.EventArgs e) {
        ach04Count += 1;
        if (ach04Count == ach04Trigger && ach04Code != 4 && achievement4Got == false) {
            //StartCoroutine(Trigger04Ach());
            achievement4Got = true;
            achievementQueue.Enqueue(Trigger04Ach());
        }
        if (ach04Count == ach08Trigger && ach08Code != 8 && achievement8Got == false) {
            //StartCoroutine(Trigger08Ach());
            achievement8Got = true;
            achievementQueue.Enqueue(Trigger08Ach());
        }
    }

    public void subscribeToInvincibilityTrigger(InvincibilityTrigger script) {
        script.pickupInvincibility += invincibilityPickup;
    }
    
    private void invincibilityPickup(object sender, System.EventArgs e) {
        ach13Count += 1;
        if (ach13Count == ach13Trigger && ach13Code != 13 && achievement13Got == false) {
            //StartCoroutine(Trigger04Ach());
            achievement13Got = true;
            achievementQueue.Enqueue(Trigger13Ach());
        }
        if (ach13Count == ach14Trigger && ach14Code != 14 && achievement14Got == false) {
            //StartCoroutine(Trigger08Ach());
            achievement14Got = true;
            achievementQueue.Enqueue(Trigger14Ach());
        }
    }

    //ASTEROIDS DESTROYED HANDLING

    public void subscribeToAsteroidsDestroyed(GameManager script) {
        script.asteroidsDestroyed += destroyedAsteroids;
    }

    private void destroyedAsteroids(object sender, System.EventArgs e) {
        ach09Count += 1;
        if (ach09Count == ach09Trigger && ach09Code != 9 && achievement9Got == false) {
            //StartCoroutine(Trigger09Ach());
            achievement9Got = true;
            achievementQueue.Enqueue(Trigger09Ach());
        }
        if (ach09Count == ach11Trigger && ach11Code != 11 && achievement11Got == false) {
            achievement11Got = true;
            achievementQueue.Enqueue(Trigger11Ach());
        }
    }

    //SCORE HANDLING

    public void subscribeToScoreGained1000(ScreenNukeTrigger script) {
        script.scoreGained1000 += gainedScore1000;
    }

    private void gainedScore1000(object sender, System.EventArgs e) {
        ach10Count += 1000;
        if (ach10Count >= ach10Trigger && ach10Code != 10 && achievement10Got == false) {
            //StartCoroutine(Trigger10Ach());
            achievement10Got = true;
            achievementQueue.Enqueue(Trigger10Ach());
        }
        if (ach10Count >= ach12Trigger && ach12Code != 12 && achievement12Got == false) {
            achievement12Got = true;
            achievementQueue.Enqueue(Trigger12Ach());
        }
    }

    public void subscribeToScoreGained200(GameManager script) {
        script.scoreGained200 += gainedScore200;
    }

    private void gainedScore200(object sender, System.EventArgs e) {
        ach10Count += 200;
        if (ach10Count >= ach10Trigger && ach10Code != 10 && achievement10Got == false) {
            //StartCoroutine(Trigger10Ach());
            achievement10Got = true;
            achievementQueue.Enqueue(Trigger10Ach());
        }
        if (ach10Count >= ach12Trigger && ach12Code != 12 && achievement12Got == false) {
            achievement12Got = true;
            achievementQueue.Enqueue(Trigger12Ach());
        }
    }

    public void subscribeToScoreGained100(GameManager script) {
        script.scoreGained100 += gainedScore100;
    }

    private void gainedScore100(object sender, System.EventArgs e) {
        ach10Count += 100;
        if (ach10Count >= ach10Trigger && ach10Code != 10 && achievement10Got == false) {
            //StartCoroutine(Trigger10Ach());
            achievement10Got = true;
            achievementQueue.Enqueue(Trigger10Ach());
        }
        if (ach10Count >= ach12Trigger && ach12Code != 12 && achievement12Got == false) {
            achievement12Got = true;
            achievementQueue.Enqueue(Trigger12Ach());
        }
    }

    public void subscribeToScoreGained50(GameManager script) {
        script.scoreGained50 += gainedScore50;
    }

    private void gainedScore50(object sender, System.EventArgs e) {
        ach10Count += 50;
        if (ach10Count >= ach10Trigger && ach10Code != 10 && achievement10Got == false) {
            //StartCoroutine(Trigger10Ach());
            achievement10Got = true;
            achievementQueue.Enqueue(Trigger10Ach());
        }
        if (ach10Count >= ach12Trigger && ach12Code != 12 && achievement12Got == false) {
            achievement12Got = true;
            achievementQueue.Enqueue(Trigger12Ach());
        }
    }

    public void subscribeToScoreGained25(GameManager script) {
        script.scoreGained25 += gainedScore25;
    }

    private void gainedScore25(object sender, System.EventArgs e) {
        ach10Count += 25;
        if (ach10Count >= ach10Trigger && ach10Code != 10 && achievement10Got == false) {
            //StartCoroutine(Trigger10Ach());
            achievement10Got = true;
            achievementQueue.Enqueue(Trigger10Ach());
        }
        if (ach10Count >= ach12Trigger && ach12Code != 12 && achievement12Got == false) {
            achievement12Got = true;
            achievementQueue.Enqueue(Trigger12Ach());
        }
    }

    // Update is called once per frame
    //void Update() {
        //test?.Invoke(this,EventArgs.Empty);
        //ach01Code = PlayerPrefs.GetInt("Ach01");
    //}

    IEnumerator Trigger01Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach01Code = 1;
        //PlayerPrefs.SetInt("Ach01", ach01Code);
        achTitle.GetComponent<Text>().text = "MORE POINTS!";
        achDesc.GetComponent<Text>().text = "Collected a Double Points Powerup";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger02Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach02Code = 2;
        //PlayerPrefs.SetInt("Ach02", ach02Code);
        achTitle.GetComponent<Text>().text = "FEELING HEALTHY!";
        achDesc.GetComponent<Text>().text = "Collected an Extra Life Powerup";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger03Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach03Code = 3;
        //PlayerPrefs.SetInt("Ach03", ach03Code);
        achTitle.GetComponent<Text>().text = "BOOM!";
        achDesc.GetComponent<Text>().text = "Collected a Nuke Powerup";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger04Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach04Code = 4;
        //PlayerPrefs.SetInt("Ach04", ach04Code);
        achTitle.GetComponent<Text>().text = "I AM SPEED!";
        achDesc.GetComponent<Text>().text = "Collected a Speed Boost Powerup";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger05Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach05Code = 5;
        //PlayerPrefs.SetInt("Ach05", ach05Code);
        achTitle.GetComponent<Text>().text = "EVEN MORE POINTS!";
        achDesc.GetComponent<Text>().text = "Collected 5 Double Points Powerups";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger06Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach06Code = 6;
        //PlayerPrefs.SetInt("Ach06", ach06Code);
        achTitle.GetComponent<Text>().text = "PERFORMANCE ENHANCED!";
        achDesc.GetComponent<Text>().text = "Collected 5 Extra Life Powerups";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger07Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach07Code = 7;
        //PlayerPrefs.SetInt("Ach07", ach07Code);
        achTitle.GetComponent<Text>().text = "BIG BOOM!";
        achDesc.GetComponent<Text>().text = "Collected 5 Nuke Powerups";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger08Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach08Code = 8;
        //PlayerPrefs.SetInt("Ach08", ach08Code);
        achTitle.GetComponent<Text>().text = "SONIC SPEED!";
        achDesc.GetComponent<Text>().text = "Collected 5 Speed Boost Powerups";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger09Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach09Code = 9;
        //PlayerPrefs.SetInt("Ach09", ach09Code);
        achTitle.GetComponent<Text>().text = "PEW PEW!";
        achDesc.GetComponent<Text>().text = "Destroy 10 Asteroids";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger10Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach10Code = 10;
        //PlayerPrefs.SetInt("Ach10", ach10Code);
        achTitle.GetComponent<Text>().text = "SCORE CHAMP!";
        achDesc.GetComponent<Text>().text = "Gain a Score of 3000 in a single play session";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger11Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach11Code = 11;
        achTitle.GetComponent<Text>().text = "SHARPSHOOTER!";
        achDesc.GetComponent<Text>().text = "Destroy 50 Asteroids";
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger12Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach12Code = 12;
        achTitle.GetComponent<Text>().text = "SCORE GOD!";
        achDesc.GetComponent<Text>().text = "Gain a Score of 10000 in a single play session";
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger13Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach13Code = 13;
        //PlayerPrefs.SetInt("Ach13", ach13Code);
        achTitle.GetComponent<Text>().text = "INDESTRUCTIBLE!";
        achDesc.GetComponent<Text>().text = "Collected an Invincibility Powerup";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
    IEnumerator Trigger14Ach() {
        coroutineTriggered = true;
        achActive = true;
        ach14Code = 14;
        //PlayerPrefs.SetInt("Ach14", ach14Code);
        achTitle.GetComponent<Text>().text = "CAN'T TOUCH THIS!";
        achDesc.GetComponent<Text>().text = "Collected 5 Invincibility Powerups";
        //achTitle.SetActive(true);
        //achDesc.SetActive(true);
        achNote.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AchievementGet");
        achievementsEarned += 1;
        yield return new WaitForSeconds(4);
        
        //Resetting UI
        coroutineTriggered = false;
        achNote.SetActive(false);
        //achTitle.SetActive(false);
        //achDesc.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
}
