using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject player;
    [SerializeField] float health;
    Rigidbody rbEnemy;
    Animator anim;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        rbEnemy = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (health > 0) {
            rbEnemy.transform.LookAt(player.transform);
            rbEnemy.velocity = transform.forward * speed;
        }
    }

    // Subtract health when hit my bullet
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Bullet")) {
            health--;
            if (health <= 0) {
                speed = 0;
                anim.SetBool("isDead", true);
                rbEnemy.isKinematic = true;
                gameObject.GetComponent<Collider>().enabled = false;
                UIController.incrementScore(1);
                Destroy(gameObject, 3f);
            }
        }

        if (other.gameObject.tag.Equals("Player")) {
            anim.SetBool("isAttacking", true);
        }
    }

    
}
