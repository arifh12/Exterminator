using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField] float speed;
    Rigidbody bullet;

    // Start is called before the first frame update
    void Start() {
        bullet = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        bullet.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
