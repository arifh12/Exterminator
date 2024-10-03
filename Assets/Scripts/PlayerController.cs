using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Player
    Rigidbody rbPlayer;
    [SerializeField] float speed;
    [SerializeField] public static int health = 10;

    // Aiming
    [SerializeField] LayerMask ground;

    // Shooting
    [SerializeField] GameObject firingPoint;
    [SerializeField] GameObject bullet;

    // Animation
    Animator anim;

    // Start is called before the first frame update
    void Start() {
        health = 10;
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        handleMovement();
        handleAim();
        handleShooting();
    }

    // Take damage when hit by enemy
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Enemy"))
            health--;
        if (health <= 0) {
            PlayerPrefs.SetInt("Score", UIController.score);
            if (UIController.score > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", UIController.score);
            SceneManager.LoadScene(2);
        }
    }

    // Handle player movement
    void handleMovement() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (movement != Vector3.zero)
            anim.SetFloat("Speed_f", 0.8f);
        else
            anim.SetFloat("Speed_f", 0f);

        //rbPlayer.MovePosition(rbPlayer.position + movement.normalized * speed * Time.deltaTime);
        rbPlayer.velocity = movement.normalized * speed;
    }

    // Handle player aim/rotation
    void handleAim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ground)) {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z)*(Time.deltaTime/Time.deltaTime));
        }
    }

    // Handle gun shooting
    void handleShooting() {
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0) {
            Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        }
    }
}
