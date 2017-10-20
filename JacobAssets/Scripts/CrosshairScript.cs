using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

	private Rect position;
	public Texture2D crosshairTexture;
	public Rigidbody bulletRigidbody;
	public Camera followCam;

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
		// This gives pixel coordinates, not in-world coordinates
		// need to try using Camera.main.ScreenPointToRay instead
		Ray ray = followCam.ScreenPointToRay(crosshairLocation);

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, surfaceLayer)) {
			Rigidbody bulletClone = (Rigidbody)Instantiate (bulletRigidbody, hit.point, Random.rotation);
		}
	}
}
