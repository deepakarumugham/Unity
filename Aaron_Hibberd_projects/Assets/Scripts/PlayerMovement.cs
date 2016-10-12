using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 100f;            // The speed that the player will move at.
	private Dictionary<string,float> rotationAngles = new Dictionary<string, float>();
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;       // The length of the ray from the camera into the scene.
	private bool headRotate = false;

	void Start(){
		// No movement
		rotationAngles.Add ("00", 0f);
		// Up Arrow
		rotationAngles.Add ("01", 0f);
		//Down Arrow
		rotationAngles.Add ("0-1", 180f);
		//Left Arrow
		rotationAngles.Add ("-10", -90f);
		//Right Arrow
		rotationAngles.Add ("10", 90f);
		//Up Right Arrow
		rotationAngles.Add ("11", 45f);
		//Up Left Arrow
		rotationAngles.Add ("-11", -45f);
		//Down Right Arrow
		rotationAngles.Add ("1-1", 135f);
		//Down Left Arrow
		rotationAngles.Add ("-1-1", -135f);
	}

	void Awake ()
	{

		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Ground");
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();


	}
	

	
	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		// Move the player around the scene.
		Animating (h, v);
		Move (h, v);
		RotateHead ();
		// Turn the player to face the mouse cursor.
		// Turning ();
			
		// Animate the player.


	}

	void RotateHead(){
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(headRotate)
			{
				headRotate = false;
			}
			else
			{
				headRotate = true;
			}
		}
		anim.SetBool ("canRotate", headRotate);

	}
	
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}
	
	void Turning ()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			Debug.Log("Inside Raycast");
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			// playerRigidbody.MoveRotation (newRotation);
		}
	}
	
	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			
		}
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("isWalking", walking);
		// Tell the animator whether or not the player is walking.
		if (walking) {
			string walkStr = "" + h + "" + v;
			float angle = 0f;
			Debug.Log(walkStr);
			rotationAngles.TryGetValue(walkStr, out angle);
			Debug.Log(angle);
			transform.rotation = Quaternion.Euler (0f, -90f * h , 0f);
		} else {
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
	}

}