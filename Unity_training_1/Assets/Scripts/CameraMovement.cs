using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = this.transform.position - target.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + offset;
		transform.rotation = target.rotation;
	
	}
}
