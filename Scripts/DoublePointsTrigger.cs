using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DoublePointsTrigger : MonoBehaviour
{
    //event to say something happened
    public event EventHandler pickupDoublePoints;

    //public GameObject doublePointsIcon;
    
    public float powerupTimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //telling glob achieves to listen to event
        GlobalAchievements.Instance.subscribeToDoublePointsTrigger(this);
        Destroy(gameObject,5f);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(activateDoublePoints());
            
            
            // FindObjectOfType<AudioManager>().Play("PowerupPickup");
            // GameManager.doublePointsActive = true;
            // //doublePointsIcon.SetActive(true);
            // //GlobalAchievements.ach01Count += 1;
            // Debug.Log(GameManager.doublePointsActive);
            // //actually triggering event to anyone who's listening
            // pickupDoublePoints?.Invoke(this, EventArgs.Empty);
            
            // StartCoroutine(RevertDoublePoints());
            // //Debug.Log(GameManager.doublePointsActive);
            // //Invoke("RevertDoublePoints", powerupTimer);
            // //StartCoroutine(GameManager.RevertDoublePoints());


            // //Debug.Log(GameManager.doublePointsActive);
            gameObject.SetActive(false);
            // //Destroy(gameObject);
        }
    }

    IEnumerator activateDoublePoints() {
        FindObjectOfType<AudioManager>().Play("PowerupPickup");
        GameManager.doublePointsActive = true;
        //doublePointsIcon.SetActive(true);
        //GlobalAchievements.ach01Count += 1;
        //Debug.Log(GameManager.doublePointsActive);
        //actually triggering event to anyone who's listening
        pickupDoublePoints?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(powerupTimer);
        GameManager.doublePointsActive = false;
        //doublePointsIcon.SetActive(false);
        //Debug.Log(GameManager.doublePointsActive);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator RevertDoublePoints() {
        yield return new WaitForSeconds(powerupTimer);
        GameManager.doublePointsActive = false;
        //doublePointsIcon.SetActive(false);
        //Debug.Log(GameManager.doublePointsActive);
        Destroy(gameObject);
    }
    
    // public void RevertDoublePoints()  {
    //     GameManager.doublePointsActive = false;
    //     //doublePointsIcon.SetActive(false);
    //     Debug.Log(GameManager.doublePointsActive);
    //     Destroy(gameObject);
    // }
}
