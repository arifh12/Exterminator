using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start() {
        delay = Random.Range(2f, 8f);
    }

    // Update is called once per frame
    void Update() {
        delay -= Time.deltaTime;
        if (delay <= 0) {
            spawnEnemy();
            delay = Random.Range(3f, 7f);
        }
    }

    // Spawn an enemy
    void spawnEnemy() {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
