using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

	private Rect position;
	public Texture2D crosshairTexture;
	public Rigidbody bulletRigidbody;
	public Camera followCam;
	public Transform car;
	public float force = 0.0f;

	// Use this for initialization
	void Start () {
		position = new Rect(
			(Input.mousePosition.x - crosshairTexture.width/2), 
			(Screen.height - Input.mousePosition.y - crosshairTexture.height/2), 
			crosshairTexture.width, 
			crosshairTexture.height);
	}
	
	// Update is called once per frame
	void Update () {
		position = new Rect(
			(Input.mousePosition.x - crosshairTexture.width/2), 
			(Screen.height - Input.mousePosition.y - crosshairTexture.height/2), 
			crosshairTexture.width, 
			crosshairTexture.height);
		if (Input.GetMouseButtonDown (0)) {
			OnClick ();
		}
	}

	void OnGUI() {
		GUI.DrawTexture (position, crosshairTexture);
	}

	void OnClick(){
		RaycastHit hit;
		int surfaceLayer = 1 << 8;
		Vector3 crosshairLocation = Input.mousePosition;
		//crosshairLocation.y = car.position.y;
		// This gives pixel coordinates, not in-world coordinates
		// need to try using Camera.main.ScreenPointToRay instead
		Ray ray = followCam.ScreenPointToRay(crosshairLocation);

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, surfaceLayer)) {
			Vector3 destination = hit.point;
			destination.y = car.position.y;
			createBullet (hit.point);
		}
	}

	void createBullet(Vector3 crosshairLoc) {
		Vector3 bulletDir = crosshairLoc - car.position;
		bulletDir = bulletDir.normalized;
		bulletDir.y = 0;
		Vector3 bulletSpawnLoc = car.position + bulletDir * 2.0f;
		Rigidbody bulletClone = (Rigidbody)Instantiate (bulletRigidbody, bulletSpawnLoc, Random.rotation);
		bulletClone.velocity = bulletDir * force;
	}
}
