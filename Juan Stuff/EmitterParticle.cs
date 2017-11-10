using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterParticle : MonoBehaviour {

    // Use this for initialization
    void Start () {
        // Invisible particle emitter
        ParticleSystem myParticles = GetComponent<ParticleSystem>();

        myParticles.Play();
    }

    // Update is called once per frame
    void Update () {
        ParticleSystem myParticles = GetComponent<ParticleSystem>();
        // Finish particle emit, destory object
        if (!myParticles.isEmitting)
        {
            Destroy(gameObject);
        }
    }
}
