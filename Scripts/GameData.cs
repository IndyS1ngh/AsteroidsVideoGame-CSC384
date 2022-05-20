using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int lives;
    public float[] playerPosition;
    public int achievementsGot;
    public bool achievement1Earned;
    public bool achievement2Earned;
    public bool achievement3Earned;
    public bool achievement4Earned;
    public bool achievement5Earned;
    public bool achievement6Earned;
    public bool achievement7Earned;
    public bool achievement8Earned;
    public bool achievement9Earned;
    public bool achievement10Earned;
    public bool achievement11Earned;
    public bool achievement12Earned;
    public bool achievement13Earned;
    public bool achievement14Earned;
    public bool bossDead;
    public float playerSpeed;

    public GameData (Player player) {
        score = GameManager.score;
        lives = GameManager.lives;
        achievementsGot = GlobalAchievements.achievementsEarned;
        achievement1Earned = GlobalAchievements.achievement1Got;
        achievement2Earned = GlobalAchievements.achievement2Got;
        achievement3Earned = GlobalAchievements.achievement3Got;
        achievement4Earned = GlobalAchievements.achievement4Got;
        achievement5Earned = GlobalAchievements.achievement5Got;
        achievement6Earned = GlobalAchievements.achievement6Got;
        achievement7Earned = GlobalAchievements.achievement7Got;
        achievement8Earned = GlobalAchievements.achievement8Got;
        achievement9Earned = GlobalAchievements.achievement9Got;
        achievement10Earned = GlobalAchievements.achievement10Got;
        achievement11Earned = GlobalAchievements.achievement11Got;
        achievement12Earned = GlobalAchievements.achievement12Got;
        achievement13Earned = GlobalAchievements.achievement13Got;
        achievement14Earned = GlobalAchievements.achievement14Got;
        bossDead = GameManager.isBossDead;
        playerSpeed = Player.thrustSpeed;

        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
    }
}
