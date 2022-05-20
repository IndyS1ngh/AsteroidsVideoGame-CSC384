using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifetime = 30.0f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start() {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction) {
        if (GameManager.score < 5000) {
            _rigidbody.AddForce(direction * this.speed);
        } else if (GameManager.score >= 5000 && GameManager.score < 10000) {
            _rigidbody.AddForce(direction * (this.speed*1.25f));
        } else if (GameManager.score >= 10000 && GameManager.score < 15000) {
            _rigidbody.AddForce(direction * (this.speed*1.5f));
        } else if (GameManager.score >= 15000 && GameManager.score < 20000) {
            _rigidbody.AddForce(direction * (this.speed*1.75f));
        } else if (GameManager.score >= 20000) {
            _rigidbody.AddForce(direction * (this.speed*2.0f));
        }
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            FindObjectOfType<AudioManager>().Play("AsteroidDeath");
            if ((this.size * 0.5f) >= this.minSize) {
                CreateSplit();
                CreateSplit();
            }

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit() {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        if (GameManager.score < 5000) {
            half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
        } else if (GameManager.score >= 5000 && GameManager.score < 10000) {
            half.SetTrajectory(Random.insideUnitCircle.normalized * (this.speed*1.25f));
        } else if (GameManager.score >= 10000 && GameManager.score < 15000) { 
            half.SetTrajectory(Random.insideUnitCircle.normalized * (this.speed*1.5f));
        } else if (GameManager.score >= 15000 && GameManager.score < 20000) {
            half.SetTrajectory(Random.insideUnitCircle.normalized * (this.speed*1.75f));
        } else if (GameManager.score >= 20000) {
            half.SetTrajectory(Random.insideUnitCircle.normalized * (this.speed*2.0f));
        }
    }

}
