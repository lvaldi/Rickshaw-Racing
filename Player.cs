using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    Player playerScript;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerScript = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleControls();

        
	}

    void HandleControls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * 5.0f * Time.deltaTime);
        }
    }
}
