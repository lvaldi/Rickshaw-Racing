using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform lookAt;

	private float distance = 20.0f;
	private float currentX = 0.0f;
	private float currentY = 60.0f;
	private float currentZ = 0.0f;

	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, currentZ);
		cam.transform.position = lookAt.position + rotation * dir; 
		cam.transform.rotation = rotation;

	}
}
