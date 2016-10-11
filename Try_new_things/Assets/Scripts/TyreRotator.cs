using UnityEngine;
using System.Collections;

public class TyreRotator : MonoBehaviour {
	float speed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (90, 0, 0) * Time.deltaTime * speed);
	}
}
