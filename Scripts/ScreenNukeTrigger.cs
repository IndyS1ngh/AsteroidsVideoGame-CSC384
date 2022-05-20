using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class ScreenNukeTrigger : MonoBehaviour
{
    
    public event EventHandler pickupScreenNuke;
    public event EventHandler scoreGained1000;
    
    GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        GlobalAchievements.Instance.subscribeToScreenNukeTrigger(this);
        GlobalAchievements.Instance.subscribeToScoreGained1000(this);
        Destroy(gameObject,5f);
    }

    void DestroyAllObjects() {
        gameObjects = GameObject.FindGameObjectsWithTag ("Asteroid");
     
        for(var i = 0 ; i < gameObjects.Length ; i ++){
            Destroy(gameObjects[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //nukeSound = GetComponent<AudioSource>();
            FindObjectOfType<AudioManager>().Play("PowerupPickup");
            DestroyAllObjects();
            //GlobalAchievements.ach03Count += 1;
            pickupScreenNuke?.Invoke(this, EventArgs.Empty);
            GameManager.score += 1000;
            //GlobalAchievements.ach10Count += 1000;
            scoreGained1000?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
