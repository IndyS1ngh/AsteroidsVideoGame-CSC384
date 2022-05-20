using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InvincibilityTrigger : MonoBehaviour
{
    public event EventHandler pickupInvincibility;
    public float powerupTimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        GlobalAchievements.Instance.subscribeToInvincibilityTrigger(this);
        Destroy(gameObject,5f);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(activateInvincibility());
            
            // GameManager.invincibilityActive = true;
            // GlobalAchievements.ach01Count += 1;
            // //Debug.Log(GameManager.invincibilityActive);
            // Invoke("RevertInvincibility", powerupTimer);
            // //StartCoroutine(GameManager.RevertInvincibility());


            //Debug.Log(GameManager.invincibilityActive);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    IEnumerator activateInvincibility() {
        FindObjectOfType<AudioManager>().Play("PowerupPickup");
        GameManager.invincibilityActive = true;
        FindObjectOfType<Player>().TurnOffCollisions();
        //doublePointsIcon.SetActive(true);
        //GlobalAchievements.ach01Count += 1;
        //Debug.Log(GameManager.doublePointsActive);
        
        //actually triggering event to anyone who's listening
        pickupInvincibility?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(powerupTimer);
        GameManager.invincibilityActive = false;
        //doublePointsIcon.SetActive(false);
        //Debug.Log(GameManager.doublePointsActive);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }


    public void RevertInvincibility()  {
        GameManager.invincibilityActive = false;
        //Debug.Log(GameManager.invincibilityActive);
        Destroy(gameObject);
    }

}
