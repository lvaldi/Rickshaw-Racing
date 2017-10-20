using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCrosshairScript : MonoBehaviour {

	private Rect position;
	private Rect basePosition;
	public Texture2D crosshairTexture;
	public Rigidbody bulletRigidbody;
	public Transform car;
	public Camera followCam;

	// Use this for initialization
	void Start () {
		Vector3 carPosition = followCam.WorldToScreenPoint (car.position);

		basePosition = new Rect (
			(carPosition.x - crosshairTexture.width / 2), 
			(Screen.height - carPosition.y - crosshairTexture.height / 2), 
			crosshairTexture.width, 
			crosshairTexture.height);

		position = basePosition;
	}

	// Update is called once per frame
	void Update () {
		Vector3 carPosition = followCam.WorldToScreenPoint (car.position);

		basePosition = new Rect (
			(carPosition.x - crosshairTexture.width / 2), 
			(Screen.height - carPosition.y - crosshairTexture.height / 2), 
			crosshairTexture.width, 
			crosshairTexture.height);

		print ("horizontal axis: ");
		print (Input.GetAxis ("Horizontal"));

		position = new Rect (
			(basePosition.x + Input.GetAxis ("Horizontal") * 250.0f),
			(basePosition.y + Input.GetAxis ("Vertical") * -250.0f),
			crosshairTexture.width,
			crosshairTexture.height);

		if (Input.GetButtonDown("Fire1")) {
			OnClick ();
		}
	}

	void OnGUI() {
		GUI.DrawTexture (position, crosshairTexture);
	}

	void OnClick(){
		RaycastHit hit;
		int surfaceLayer = 1 << 8;
		Vector3 crosshairLocation = new Vector3 (
			(position.x + crosshairTexture.width / 2), 
			(Screen.height - position.y - crosshairTexture.height / 2),
			0);
		// This gives pixel coordinates, not in-world coordinates
		// need to try using Camera.main.ScreenPointToRay instead
		Ray ray = followCam.ScreenPointToRay(crosshairLocation);

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, surfaceLayer)) {
			Rigidbody bulletClone = (Rigidbody)Instantiate (bulletRigidbody, hit.point, Random.rotation);
		}
	}
}
