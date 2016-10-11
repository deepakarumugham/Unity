using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	ArrayList path;

	private Animator animator;
	private int currentPosition;
	private string currentAnim;

	void Start () {
		animator = GetComponent<Animator> ();
		currentPosition = 1;
		transform.position = GameObject.Find ("Cube-1").transform.position;
		currentAnim = null;
	}
	
	void Update () {
		ArrayList path = CalculatePath ();
		if (path != null) {
			// playAnimation("standing_walk_forward_inPlace");
			foreach(GameObject pathPoint in path)
			{
				MoveToPosition (pathPoint.transform);
			}
		}
		
	}

	/**
	 * Calculates the points from current position to end position
	 */
	ArrayList CalculatePath(){
		ArrayList path = null;
		string keyPressed = Input.inputString;
		int moveBy = -1;
		switch (keyPressed) {
		case "1":
			moveBy = 1;
			break;
		case "2":
			moveBy = 2;
			break;
		case "3":
			moveBy = 3;
			break;
		default:
			break;
		}
		if (moveBy != -1) {
			path = new ArrayList (0);
			int endPosition = currentPosition + moveBy;
			// Find the GameObjects from current to end position
			for(int i = currentPosition + 1; i <= endPosition; i++){
				path.Add(GameObject.Find("Cube-" +  i));
			}
			currentPosition += moveBy;
		}
		return path;
	}


	void MoveToPosition(Transform target){
		Vector3 currentPosition =  transform.position;
		Vector3 targetPosition = target.position;

		playAnimation("standing_walk_forward_inPlace");
		float diff = Vector3.Distance (currentPosition, targetPosition);
		while ( diff > 0f) {
			transform.position = Vector3.MoveTowards (currentPosition, targetPosition, Time.fixedDeltaTime);
			currentPosition =  transform.position;
			diff = Vector3.Distance (currentPosition, targetPosition);
		}
		playAnimation("unarmed_idle");

	}

	void playAnimation(string animation){
			animator.Play(animation);
	}
}
