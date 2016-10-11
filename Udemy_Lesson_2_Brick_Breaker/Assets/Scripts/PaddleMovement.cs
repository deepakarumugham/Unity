using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {

	private AudioSource audioSource;
	public bool autoplay = false;
	private Ball ball;
	private float minX = 0.5f;
	private float maxX = 15.5f;

	void Start(){
		audioSource = GetComponent<AudioSource> ();
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	// Update is called once per frame
	void Update () {
		if (!autoplay) {
			HandleMouseMovement ();
		} 
		else {
			AutoPlay();	
		}
	}

	void AutoPlay(){
		Vector3 newPosition = new Vector3 (ball.transform.position.x,
		                                   this.transform.position.y, 
		                                   0f);
		
		this.transform.position = newPosition;
	}
	void HandleMouseMovement(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 newPosition = new Vector3 (Mathf.Clamp (mousePosInBlocks, minX, maxX),
		                                   this.transform.position.y, 
		                                   0f);
		
		this.transform.position = newPosition;
	}

	public void OnTriggerEnter2D(Collider2D trigger){
		switch (trigger.gameObject.tag) {
		case "flower":
			audioSource.Play();
			this.gameObject.transform.localScale += new Vector3(1f,0f,0f);
			minX += 0.90f;
			maxX -= 0.90f;
			trigger.gameObject.SetActive(false);
			break;
		case "lightSaber":
			LightSaber lightSaber = gameObject.GetComponentInChildren<LightSaber>();
			lightSaber.isBeamEnabled = true;
			Destroy(trigger.gameObject);
			break;
		}



	}
}
