using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    
    public Asteroid asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount = 1;

    private void Start() {
        //StartCoroutine(SpawnCopy(this.spawnRate));
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn() {
        for (int i = 0; i < this.spawnAmount; i++) {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
            alterSpawnAmount();
            //Debug.Log(this.spawnRate);
            Debug.Log(this.spawnAmount);
        }
    }

    // IEnumerator SpawnCopy(float spawnRate) {
    //     while (true) {
    //         Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
    //         Vector3 spawnPoint = this.transform.position + spawnDirection;
    //         float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
    //         Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
    //         Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
    //         asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
    //         asteroid.SetTrajectory(rotation * -spawnDirection);
    //         yield return new WaitForSeconds(spawnRate);
    //         alterSpawnRate();
    //         Debug.Log(this.spawnRate);
    //         //Debug.Log(this.spawnAmount);
    //     }
    // }

    private void alterSpawnAmount() {
        if (GameManager.score < 10000) {
            //this.spawnRate = 2.0f;
            this.spawnAmount = 1;
        } else if (GameManager.score >= 10000 && GameManager.score < 20000) {
            //this.spawnRate = 1.0f;
            this.spawnAmount = 2;
        } else if (GameManager.score >= 20000) {
            //this.spawnRate = 0.1f;
            this.spawnAmount = 3;
        }
    }

    // private void alterSpawnRate() {
    //     if (GameManager.score < 1000) {
    //         this.spawnRate = 2.0f;
    //         //this.spawnAmount = 1;
    //     } else if (GameManager.score >= 1000 && GameManager.score < 2000) {
    //         this.spawnRate = 1.25f;
    //         //this.spawnAmount = 2;
    //     } else {
    //         this.spawnRate = 0.5f;
    //         //this.spawnAmount = 3;
    //     }
    // }
}
