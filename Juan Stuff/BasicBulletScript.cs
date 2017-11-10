using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletScript : MonoBehaviour {
    public GameObject emmitterObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
        GameObject emmitter = (GameObject)Instantiate(emmitterObject, transform.position, transform.rotation);
        
		Destroy (gameObject);
    }
}
