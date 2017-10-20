using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    
    public Quaternion targetRotation;


    public List<GameObject> wheels;
    private float wheelVelocity;

    private float tightness = 1.0f;

    private float turnSpeed;
    private float deltaTurn;

    private Vector3 updatedForward;
  
    private bool turning;
    private bool thrusting;


    private TrailRenderer trailRend;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        GetWheels();

        targetRotation = transform.rotation;
        wheelVelocity = 0f;
        turnSpeed = 0f;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SpinWheels();
        HandleControls();
       // OrientUp();
	}

    void HandleControls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (wheelVelocity < 175f)
            {
                wheelVelocity+= 2.0f;
            }
            rb.AddRelativeForce(Vector3.forward * speed);

            thrusting = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (wheelVelocity > -175f)
            {
                wheelVelocity-= 2.0f;
            }
            rb.AddRelativeForce(-Vector3.forward * speed);

            thrusting = true;
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            if (turnSpeed < 60)
                turnSpeed += 4f;
            //transform.RotateAround(transform.position, Vector3.up, -turnSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            turning = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (turnSpeed < 60)
                turnSpeed += 4f;
            //transform.RotateAround(transform.position, Vector3.up, -turnSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            turning = true;
        }




        if (Input.GetKeyUp(KeyCode.D))
        {
            turning = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            turning = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            thrusting = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            thrusting = false;
        }

        if (!turning)
        {
            if (turnSpeed > 0) 
                turnSpeed -= 2.0f;
        
        }

        if (!thrusting)
        {
            if (wheelVelocity > 0)
                wheelVelocity -= 2.0f;

            if (wheelVelocity < 0)
                wheelVelocity += 2.0f;
        }
    }

    void OrientUp()
    {
        Ray rayToGround = new Ray();
        rayToGround.origin = transform.position;
        rayToGround.direction = Vector3.down;
        
        

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(rayToGround, out hitInfo);
        
        if (hit)
        {
            Debug.Log(hitInfo.normal);
           //transform.up = Vector3.Slerp(transform.up, hitInfo.normal ,Time.deltaTime * 2.0f);
           
        }
    }

    void GetWheels()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Wheel")
            {
                wheels.Add(child.gameObject);
                Debug.Log("Added" + child.gameObject.name);
                
            }
        }
    }

    void SpinWheels()
    {
        foreach (GameObject g in wheels)
        {
            g.transform.Rotate(Vector3.right, wheelVelocity * 4.0f * Time.deltaTime);
        }
    }
}
