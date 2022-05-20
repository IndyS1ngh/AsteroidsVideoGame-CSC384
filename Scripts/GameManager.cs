using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Player player;
    public ParticleSystem explosion;
    public static int lives = 3;
    public float respawnTime = 3.0f;
    public float immuneTime = 3.0f;
    public static int score = 0;
    public static bool doublePointsActive = false; 
    public static bool invincibilityActive = false; 
    public bool gameHasEnded = false;
    public static bool isBossSpawned = false;
    public static bool isBossDead = false;
    public GameObject powerPrefab;
    public GameObject powerPrefab1;
    public GameObject powerPrefab2;
    public GameObject powerPrefab3;
    public GameObject Boss;
    public GameObject doublePointsIcon;
    public GameObject invincibilityIcon;
    public GameObject powerPrefab4;
    public float whichPrefab;
    public float spawnChance;
    public event EventHandler asteroidsDestroyed;
    public event EventHandler scoreGained200;
    public event EventHandler scoreGained100;
    public event EventHandler scoreGained50;
    public event EventHandler scoreGained25;
    
    void Start() {
        GlobalAchievements.Instance.subscribeToAsteroidsDestroyed(this);
        GlobalAchievements.Instance.subscribeToScoreGained200(this);
        GlobalAchievements.Instance.subscribeToScoreGained100(this);
        GlobalAchievements.Instance.subscribeToScoreGained50(this);
        GlobalAchievements.Instance.subscribeToScoreGained25(this);
    }
    
    void Update() {
        if (doublePointsActive == true) {
            doublePointsIcon.SetActive(true);
            Invoke("setDoublePointsOff", 5f);
        } else {
            doublePointsIcon.SetActive(false);
        }
        if (invincibilityActive == true) {
            invincibilityIcon.SetActive(true);
            Invoke("setInvincibilityOff", 5f);
        } else {
            invincibilityIcon.SetActive(false);
        }
    }

    public void setDoublePointsOff() {
        doublePointsActive = false;
        //Debug.Log(doublePointsActive);
    }

    public void setInvincibilityOff() {
        invincibilityActive = false;
        try {
            FindObjectOfType<Player>().TurnOnCollisions();
        } catch (NullReferenceException ex) {
            Debug.Log("Player is dead!");
        }
        //FindObjectOfType<Player>().TurnOnCollisions();
        //Debug.Log(doublePointsActive);
    }

    public void AsteroidDestroyed(Asteroid asteroid) {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        //GlobalAchievements.ach09Count += 1;
        asteroidsDestroyed?.Invoke(this, EventArgs.Empty);
        this.powerPrefab.transform.position = asteroid.transform.position;
        this.powerPrefab1.transform.position = asteroid.transform.position;
        this.powerPrefab2.transform.position = asteroid.transform.position;
        this.powerPrefab3.transform.position = asteroid.transform.position;
        this.powerPrefab4.transform.position = asteroid.transform.position;
        spawnChance = UnityEngine.Random.Range(0.0f, 10.0f);
        whichPrefab = UnityEngine.Random.Range(0.0f, 15.0f);
        //Debug.Log(whichPrefab);
        if (spawnChance <= 5.0f) {
            if (whichPrefab <= 3.0f) {
                StartCoroutine(SpawnPowerup(powerPrefab, 1.0f));
            } else if (whichPrefab >= 3.0f && whichPrefab < 6.0f) {
                StartCoroutine(SpawnPowerup(powerPrefab1, 1.0f));
            } else if (whichPrefab >= 6.0f && whichPrefab < 9.0f) {
                StartCoroutine(SpawnPowerup(powerPrefab2, 1.0f));
            } else if (whichPrefab >= 9.0f && whichPrefab < 12.0f){
                StartCoroutine(SpawnPowerup(powerPrefab3, 1.0f));
            } else {
                StartCoroutine(SpawnPowerup(powerPrefab4, 1.0f));
            }
        }

        //Invoke("SpawnPowerup", 5f);
        //StartCoroutine(SpawnPowerup(powerPrefab, 5.0f));
        if (doublePointsActive == false) {
            if (asteroid.size < 0.70f) {
                score += 100;
                //GlobalAchievements.ach10Count += 100;
                scoreGained100?.Invoke(this, EventArgs.Empty);
            } else if (asteroid.size < 1.20f) {
                score += 50;
                //GlobalAchievements.ach10Count += 50;
                scoreGained50?.Invoke(this, EventArgs.Empty);
            } else {
                score += 25;
                //GlobalAchievements.ach10Count += 25;
                scoreGained25?.Invoke(this, EventArgs.Empty);
            } 
        } else {
            //Invoke("RevertDoublePoints", 3.0f);
            if (asteroid.size < 0.70f) {
                score += 200;
                //GlobalAchievements.ach10Count += 200;
                scoreGained200?.Invoke(this, EventArgs.Empty);
            } else if (asteroid.size < 1.20f) {
                score += 100;
                //GlobalAchievements.ach10Count += 100;
                scoreGained100?.Invoke(this, EventArgs.Empty);
            } else {
                score += 50;
                //GlobalAchievements.ach10Count += 50;
                scoreGained50?.Invoke(this, EventArgs.Empty);
            } 
        }
        if (score >= 5000) {
            BossSpawned();
        }
    }

    public void BossSpawned() {
        if (isBossSpawned == false && isBossDead == false) {
            isBossSpawned = true;
            this.Boss.SetActive(true);
            FindObjectOfType<AudioManager>().Play("BossSpawn");
        } else {
            return;
        }
    }

    IEnumerator SpawnPowerup(GameObject pp, float timer) {
        yield return new WaitForSeconds(timer);
        GameObject PU;
        PU = Instantiate(pp, pp.transform.position, Quaternion.identity);
    }

    //public static IEnumerator RevertDoublePoints()  {
    //    yield return new WaitForSeconds (3.0f);
    //    doublePointsActive = false;
    //    Debug.Log(doublePointsActive);
    //}

    public void PlayerDied() {
        //if (invincibilityActive == false) {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        lives--;
        if (lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }
        //} else {
            //this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
            //Invoke(nameof(TurnOnCollisions), 0.5f);
        //}
    }

    private void Respawn() {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        doublePointsActive = false; 
        invincibilityActive = false; 
        Invoke(nameof(TurnOnAllCollisions), this.immuneTime);
    }

    private void TurnOnAllCollisions() {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Exit();
        }
        //lives = 3;
        //score = 0;
        //Invoke(nameof(Respawn), this.respawnTime);
    }

    void Exit() {
        gameHasEnded = false;
        SceneManager.LoadScene("GameOverMenu");
        // score = 0;
        // GlobalAchievements.ach10Count = 0;
        // lives = 3;
        // doublePointsActive = false;
        // Player.thrustSpeed = 1.0f;
    }
}
