using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	int floormask;
	float camRayLength = 100f;
	// Use this for initialization
	float prevHoriPos;
	float prevVerPos;

	void Awake(){
		floormask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
		prevHoriPos = 0f;
		prevVerPos = 0f;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		prevHoriPos = moveHorizontal;
		prevVerPos = moveVertical;

		Move (moveHorizontal, moveVertical);
		Animating (moveHorizontal, moveVertical);



	}

	void Move(float h, float v){
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
	}

	void Animating(float h, float v){
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
