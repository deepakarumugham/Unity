using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	public float speed = 10f;
	AudioSource playerAudio;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		playerAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveVertical, 0.0f, -moveHorizontal);
		rb.AddForce (movement*speed);
		PlayAudio ();
	}

	void PlayAudio(){
		if (playerAudio.isPlaying) {
			return;
		}
		playerAudio.Play ();
	}
}
