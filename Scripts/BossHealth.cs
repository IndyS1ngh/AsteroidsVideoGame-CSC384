using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public static int health = 20;
	public ParticleSystem explosion;
    public bool isInvulnerable = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            TakeDamage();
        }
    }

	public void TakeDamage() {
        if (isInvulnerable) {
            return;
        }
        
        FindObjectOfType<AudioManager>().Play("BossHurt");
        health -= 1;

        if (health <= 10) {
            GetComponent<Animator>().SetBool("isEnraged",true);
        }

		if (health <= 0){
			Die();
		}
	}

	void Die(){
		GameManager.isBossDead = true;
        FindObjectOfType<AudioManager>().Play("BossDeath");
        this.explosion.transform.position = Boss_Idle.rb.transform.position;
        this.explosion.Play();
		Destroy(gameObject);
	}

}
