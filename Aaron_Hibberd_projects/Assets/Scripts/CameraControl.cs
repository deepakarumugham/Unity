using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public GameObject player;
	public float smoothing = 5f;
	private Vector3 offset;
	
	
	void Start ()
	{
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
	{
		Vector3 targetCamPos = player.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
