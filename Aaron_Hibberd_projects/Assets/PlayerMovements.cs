using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovements : MonoBehaviour {
	public Animator animator;
	private bool isRunning = false;
	private bool isJumping = false; 
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		isJumping = CrossPlatformInputManager.GetButtonDown("Jump");
	}

	void FixedUpdate(){
		performMovements ();
	}

	void performMovements(){

		if(isJumping){
			if(isRunning){
				animator.Play("unarmed_jump_running");
			}else{
				animator.Play("unarmed_jump");
			}
		}

	}
}
