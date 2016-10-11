using UnityEngine;
using System.Collections;

public class TowerMovement : MonoBehaviour {

	public float speed = 25.0f;

	void Update() {

		//float h = Input.GetAxis("Mouse X");
		//float v = Input.GetAxis("Mouse Y");
		//float rotationX = Mathf.Clamp (h, -40, 40);
		//float rotationY = Mathf.Clamp (v, -80, 80);

		// transform.Rotate(new Vector3(v, -h, 0) * Time.deltaTime * speed);
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (-moveVertical, moveHorizontal, 0.0f);
		
		transform.Rotate(movement * Time.deltaTime * speed);
	}

}
