using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedBoostTrigger : MonoBehaviour
{

    public event EventHandler pickupSpeedBoost;

    // Start is called before the first frame update
    void Start()
    {
        GlobalAchievements.Instance.subscribeToSpeedBoostTrigger(this);
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            FindObjectOfType<AudioManager>().Play("PowerupPickup");
            Player.thrustSpeed += 0.25f;
            //GlobalAchievements.ach04Count += 1;
            pickupSpeedBoost?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
