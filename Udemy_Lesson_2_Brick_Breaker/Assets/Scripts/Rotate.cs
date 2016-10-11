using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float speed = 4f;
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime * speed);
	}
}
