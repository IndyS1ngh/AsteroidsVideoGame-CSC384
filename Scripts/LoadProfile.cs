using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProfile : MonoBehaviour
{
    public static bool loadFromProfile1 = false;
    public static bool loadFromProfile2 = false;
    public static bool loadFromProfile3 = false;
    
    public void LoadGame1 () {
        SceneManager.LoadScene(1);
        //GameData data = SaveSystem.LoadGame1();
        if (ProfileSystem.data1 != null) {
        loadFromProfile1 = true;
        GameManager.score = ProfileSystem.data1.score;
        GameManager.lives = ProfileSystem.data1.lives;
        GlobalAchievements.achievementsEarned = ProfileSystem.data1.achievementsGot;
        GlobalAchievements.achievement1Got = ProfileSystem.data1.achievement1Earned;
        GlobalAchievements.achievement2Got = ProfileSystem.data1.achievement2Earned;
        GlobalAchievements.achievement3Got = ProfileSystem.data1.achievement3Earned;
        GlobalAchievements.achievement4Got = ProfileSystem.data1.achievement4Earned;
        GlobalAchievements.achievement5Got = ProfileSystem.data1.achievement5Earned;
        GlobalAchievements.achievement6Got = ProfileSystem.data1.achievement6Earned;
        GlobalAchievements.achievement7Got = ProfileSystem.data1.achievement7Earned;
        GlobalAchievements.achievement8Got = ProfileSystem.data1.achievement8Earned;
        GlobalAchievements.achievement9Got = ProfileSystem.data1.achievement9Earned;
        GlobalAchievements.achievement10Got = ProfileSystem.data1.achievement10Earned;
        GlobalAchievements.achievement11Got = ProfileSystem.data1.achievement11Earned;
        GlobalAchievements.achievement12Got = ProfileSystem.data1.achievement12Earned;
        GlobalAchievements.achievement13Got = ProfileSystem.data1.achievement13Earned;
        GlobalAchievements.achievement14Got = ProfileSystem.data1.achievement14Earned;
        GameManager.isBossDead = ProfileSystem.data1.bossDead;
        Player.thrustSpeed = ProfileSystem.data1.playerSpeed;

        //SceneManager.LoadScene(1);
        } else {
            Debug.LogError("No Save data found in Slot 1!");
        }
    }

    public void LoadGame2 () {
        SceneManager.LoadScene(1);
        //GameData data = SaveSystem.LoadGame2();
        if (ProfileSystem.data2 != null) {
        loadFromProfile2 = true;
        GameManager.score = ProfileSystem.data2.score;
        GameManager.lives = ProfileSystem.data2.lives;
        GlobalAchievements.achievementsEarned = ProfileSystem.data2.achievementsGot;
        GlobalAchievements.achievement1Got = ProfileSystem.data2.achievement1Earned;
        GlobalAchievements.achievement2Got = ProfileSystem.data2.achievement2Earned;
        GlobalAchievements.achievement3Got = ProfileSystem.data2.achievement3Earned;
        GlobalAchievements.achievement4Got = ProfileSystem.data2.achievement4Earned;
        GlobalAchievements.achievement5Got = ProfileSystem.data2.achievement5Earned;
        GlobalAchievements.achievement6Got = ProfileSystem.data2.achievement6Earned;
        GlobalAchievements.achievement7Got = ProfileSystem.data2.achievement7Earned;
        GlobalAchievements.achievement8Got = ProfileSystem.data2.achievement8Earned;
        GlobalAchievements.achievement9Got = ProfileSystem.data2.achievement9Earned;
        GlobalAchievements.achievement10Got = ProfileSystem.data2.achievement10Earned;
        GlobalAchievements.achievement11Got = ProfileSystem.data2.achievement11Earned;
        GlobalAchievements.achievement12Got = ProfileSystem.data2.achievement12Earned;
        GlobalAchievements.achievement13Got = ProfileSystem.data2.achievement13Earned;
        GlobalAchievements.achievement14Got = ProfileSystem.data2.achievement14Earned;
        GameManager.isBossDead = ProfileSystem.data2.bossDead;
        Player.thrustSpeed = ProfileSystem.data2.playerSpeed;

        //SceneManager.LoadScene(1);
        } else {
            Debug.LogError("No Save data found in Slot 2!");
        }
    }

    public void LoadGame3 () {
        //StartCoroutine(loadScene());
        SceneManager.LoadScene(1);
        //GameData data = SaveSystem.LoadGame3();
        if (ProfileSystem.data3 != null) {
        loadFromProfile3 = true;
        GameManager.score = ProfileSystem.data3.score;
        GameManager.lives = ProfileSystem.data3.lives;
        GlobalAchievements.achievementsEarned = ProfileSystem.data3.achievementsGot;
        GlobalAchievements.achievement1Got = ProfileSystem.data3.achievement1Earned;
        GlobalAchievements.achievement2Got = ProfileSystem.data3.achievement2Earned;
        GlobalAchievements.achievement3Got = ProfileSystem.data3.achievement3Earned;
        GlobalAchievements.achievement4Got = ProfileSystem.data3.achievement4Earned;
        GlobalAchievements.achievement5Got = ProfileSystem.data3.achievement5Earned;
        GlobalAchievements.achievement6Got = ProfileSystem.data3.achievement6Earned;
        GlobalAchievements.achievement7Got = ProfileSystem.data3.achievement7Earned;
        GlobalAchievements.achievement8Got = ProfileSystem.data3.achievement8Earned;
        GlobalAchievements.achievement9Got = ProfileSystem.data3.achievement9Earned;
        GlobalAchievements.achievement10Got = ProfileSystem.data3.achievement10Earned;
        GlobalAchievements.achievement11Got = ProfileSystem.data3.achievement11Earned;
        GlobalAchievements.achievement12Got = ProfileSystem.data3.achievement12Earned;
        GlobalAchievements.achievement13Got = ProfileSystem.data3.achievement13Earned;
        GlobalAchievements.achievement14Got = ProfileSystem.data3.achievement14Earned;
        GameManager.isBossDead = ProfileSystem.data3.bossDead;
        Player.thrustSpeed = ProfileSystem.data3.playerSpeed;
        
        //StartCoroutine(setPos(ProfileSystem.data3));
        //SceneManager.LoadScene(1);
        } else {
            Debug.LogError("No Save data found in Slot 3!");
        }
    }

    // IEnumerator setPos(GameData data) {
    //     //yield return new WaitForSeconds(5f);
    //     Vector3 pos;
    //     pos.x = data.playerPosition[0];
    //     pos.y = data.playerPosition[1];
    //     pos.z = data.playerPosition[2];
    //     Player.Instance.transform.position = pos;
    //     yield return new WaitForSeconds(0f);
    // }

    // IEnumerator loadScene() {
    //     SceneManager.LoadScene(1);
    //     yield return new WaitForSeconds(0f);
    // }
}
