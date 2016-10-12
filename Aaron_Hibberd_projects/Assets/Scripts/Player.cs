using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float playerSpeed = 100f;

	private Rigidbody rigidBody;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float walk = Input.GetAxisRaw ("Horizontal");
		float verticalWalk = Input.GetAxisRaw ("Vertical");

		if (walk == 0f || verticalWalk == 0f) {
			animator.SetBool ("isWalking", false);
			Debug.Log("Deepak--False");
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			rigidBody.AddForce(playerSpeed * walk * Time.deltaTime, 0f, 0f);
		} else {
			animator.SetBool("isWalking", true);
			Debug.Log("Deepak--True");
			transform.rotation = Quaternion.Euler(0f, -90f * walk, 0f);
			// rigidBody.AddForce(playerSpeed * walk * Time.deltaTime, 0f, 0f);
		}
	
	}
}
