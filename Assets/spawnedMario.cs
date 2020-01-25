using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedMario: MonoBehaviour {

    int secondsAlive;

    void Start() {
        Rigidbody newMarioRB = gameObject.GetComponent<Rigidbody>();
        newMarioRB.constraints = RigidbodyConstraints.FreezePositionZ;
        newMarioRB.useGravity = true;

        secondsAlive = 15;
        StartCoroutine(die());
    }

    IEnumerator die() {
        if (secondsAlive > 0) {
            yield return new WaitForSeconds(secondsAlive);
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }
}
