using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public static Player Instance;
    public Bullet bulletPrefab;
    public static float thrustSpeed = 1.0f;
    public float turnSpeed = 0.25f;
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    public float invincibleTime = 3.0f;
    public Button saveButton;
    public Button saveToProf1;
    public Button saveToProf2;
    public Button saveToProf3;
    //bool isInvincible = false;
    
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (Instance) {
            Destroy(this);
        } else {
            Instance = this;
        }
        if (LoadProfile.loadFromProfile1 == true) {
            LoadPos(ProfileSystem.data1);
        }
        if (LoadProfile.loadFromProfile2 == true) {
            LoadPos(ProfileSystem.data2);
        }
        if (LoadProfile.loadFromProfile3 == true) {
            LoadPos(ProfileSystem.data3);
        }
    }

    private void Update() {
        _thrusting = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            _turnDirection = -1.0f;
        } else {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void FixedUpdate() {
        if (_thrusting) {
            _rigidbody.AddForce(this.transform.up * thrustSpeed);
        }

        if (_turnDirection != 0.0f) {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }

    private void Shoot() {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
        FindObjectOfType<AudioManager>().Play("PlayerShoot");
    }

    public void TurnOnCollisions() {
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void TurnOffCollisions() {
        this.gameObject.layer = LayerMask.NameToLayer("IgnoreEnemyCollisions");
    }

    // public void SetInvincible() {
    //     isInvincible = true;
    //     CancelInvoke("SetDamageable");
    //     Invoke("SetDamageable", invincibleTime);
    // }

    // void SetDamageable() {
    //     isInvincible = false;
    // }

    private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "BossBullet" || collision.gameObject.tag == "Boss") {
                //Debug.Log(GameManager.invincibilityActive);
                if (GameManager.invincibilityActive == false) {
                    _rigidbody.velocity = Vector3.zero;
                    _rigidbody.angularVelocity = 0.0f;
                    this.gameObject.SetActive(false);

                    FindObjectOfType<AudioManager>().Play("PlayerDeath");

                    FindObjectOfType<GameManager>().PlayerDied();
                } else {
                    return;
                    //this.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
                    //TurnOnCollisions();
                    //Invoke("TurnOnCollisions", 0.5f);
                }
            //if (collision.gameObject.tag == "BossBullet") {
                //Debug.Log(GameManager.invincibilityActive);
                //if (GameManager.invincibilityActive == false) {
                //_rigidbody.velocity = Vector3.zero;
                //_rigidbody.angularVelocity = 0.0f;
                //this.gameObject.SetActive(false);
                //FindObjectOfType<GameManager>().PlayerDied();
            //} 
            //if (collision.gameObject.tag == "Boss") {
                //Debug.Log(GameManager.invincibilityActive);
                //if (GameManager.invincibilityActive == false) {
                //_rigidbody.velocity = Vector3.zero;
                //_rigidbody.angularVelocity = 0.0f;
                //this.gameObject.SetActive(false);
                //FindObjectOfType<GameManager>().PlayerDied();
            }
    }   
        
        //  else {
        //         //this.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        //         //TurnOnCollisions();
        //         //Invoke("TurnOnCollisions", 0.5f);
        // }

    public void SaveGame1 () {
        SaveSystem.SaveGame1(this);
        saveButton.gameObject.SetActive(true);
        saveToProf1.gameObject.SetActive(false);
        saveToProf2.gameObject.SetActive(false);
        saveToProf3.gameObject.SetActive(false);
        //profileRef = PlayerPrefs.SetInt("ProfileData", selectedProfile);
    }

    public void LoadPos (GameData data) {
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        transform.position = position;
    }
    
    public void SaveGame2 () {
        SaveSystem.SaveGame2(this);
        saveButton.gameObject.SetActive(true);
        saveToProf1.gameObject.SetActive(false);
        saveToProf2.gameObject.SetActive(false);
        saveToProf3.gameObject.SetActive(false);
        //profileRef = PlayerPrefs.SetInt("ProfileData", selectedProfile);
    }

    // public void LoadGame2 () {
    //     GameData data = SaveSystem.LoadGame2();
    //     GameManager.score = data.score;
    //     GameManager.lives = data.lives;
    //     Vector3 position;
    //     position.x = data.playerPosition[0];
    //     position.y = data.playerPosition[1];
    //     position.z = data.playerPosition[2];
    //     transform.position = position;
    // }

    public void SaveGame3 () {
        SaveSystem.SaveGame3(this);
        saveButton.gameObject.SetActive(true);
        saveToProf1.gameObject.SetActive(false);
        saveToProf2.gameObject.SetActive(false);
        saveToProf3.gameObject.SetActive(false);
        //profileRef = PlayerPrefs.SetInt("ProfileData", selectedProfile);
    }

    // public void LoadGame3 () {
    //     GameData data = SaveSystem.LoadGame3();
    //     GameManager.score = data.score;
    //     GameManager.lives = data.lives;
    //     Vector3 position;
    //     position.x = data.playerPosition[0];
    //     position.y = data.playerPosition[1];
    //     position.z = data.playerPosition[2];
    //     transform.position = position;
    // }

}

        //}
    //}

//}
