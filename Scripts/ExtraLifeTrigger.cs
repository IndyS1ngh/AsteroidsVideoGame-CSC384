using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExtraLifeTrigger : MonoBehaviour
{
    
    //event to say something happened
    public event EventHandler pickupExtraLife;

    // Start is called before the first frame update
    void Start()
    {
        GlobalAchievements.Instance.subscribeToExtraLifeTrigger(this);
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            FindObjectOfType<AudioManager>().Play("PowerupPickup");
            GameManager.lives++;
            //GlobalAchievements.ach02Count += 1;
            pickupExtraLife?.Invoke(this, EventArgs.Empty);
            //Debug.Log(GameManager.lives);
            Destroy(gameObject);
        }
    }

}
