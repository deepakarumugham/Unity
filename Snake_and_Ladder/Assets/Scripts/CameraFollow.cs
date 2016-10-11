using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	// Use this for initialization

	// The speed with which the camera will be following.
	public float smoothing = 2f;

	// The initial offset from the target.	
	Vector3 offset;                     
	void Start () {
		offset = transform.position - player.position;
	}
	
	void FixedUpdate () {
		Vector3 followPosition = player.position + offset;
		transform.position = Vector3.Lerp (transform.position, followPosition, Time.deltaTime * smoothing);
	}
}
