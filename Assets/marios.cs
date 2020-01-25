using System;
using System.Collections;
using UnityEngine;
using rand = UnityEngine.Random;

public class marios: MonoBehaviour {

    Rigidbody rb;
    public int spinStrength;
    public float forceFrequency; // times per second
    public float spawnFrequency; 


    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(force());
        StartCoroutine(spawn());

        Physics.gravity = new Vector3(0, -1, 0);
    }

    IEnumerator force() {
        while (true) {
            addSpin();
            yield return new WaitForSeconds(1/ forceFrequency);
        }
    }
    private void addSpin() {
        rb.AddTorque(new Vector3(rand.value * spinStrength, rand.value * spinStrength, rand.value * spinStrength));
    }

    IEnumerator spawn() {
        while (true) {
            spawnMario();
            yield return new WaitForSeconds(1 / spawnFrequency);
        }
    }

    private void spawnMario() {
        GameObject newMario = Instantiate(gameObject, transform.position, transform.rotation);
        Destroy(newMario.GetComponent<marios>());
        newMario.AddComponent<spawnedMario>();
    }
}
