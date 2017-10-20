using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour {

    public Transform player;
    public Transform camTarget;
    public Vector3 offset;

    public float tightness = 0.5f;


    // Use this for initialization
    void Start() {
        offset = camTarget.position - player.position;
       
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = Vector3.Slerp(transform.position, player.position + offset, Time.deltaTime * 7.0f);
    }
}
