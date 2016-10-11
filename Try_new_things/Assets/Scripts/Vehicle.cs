using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{

	private Rigidbody rb;
	float speed = 10f;
	private GameObject[] frontTires;
	private GameObject[] rearTires;

	public float TireAngle = 0f;
	private const float MAX_ANGLE = 90f;
	public float TireTurnSpeed = 100f;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		frontTires = GameObject.FindGameObjectsWithTag ("Front_tires");
		rearTires = GameObject.FindGameObjectsWithTag ("Rear_tires");

		if (Input.GetKey (KeyCode.UpArrow)) {
			foreach (GameObject tire in frontTires) {
				tire.transform.Rotate (new Vector3 (90, 0, 0) * Time.deltaTime * speed);
			}
			foreach (GameObject tire in rearTires) {
				tire.transform.Rotate (new Vector3 (90, 0, 0) * Time.deltaTime * speed);
			}
			rb.AddForce (movement * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			foreach (GameObject tire in frontTires) {
				tire.transform.Rotate (new Vector3 (-90, 0, 0) * Time.deltaTime * speed);
			}
			foreach (GameObject tire in rearTires) {
				tire.transform.Rotate (new Vector3 (-90, 0, 0) * Time.deltaTime * speed);
			}
			rb.AddForce (movement * speed * 0.5f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			foreach (GameObject tire in frontTires) {
				if (TireAngle < MAX_ANGLE) {

					tire.transform.localEulerAngles = new Vector3 (0f, transform.localEulerAngles.y + (TireTurnSpeed * Time.deltaTime), 0f);
					TireAngle += TireTurnSpeed * Time.deltaTime;
				}
			}
		} 
		if (Input.GetKey (KeyCode.LeftArrow)) {
			foreach (GameObject tire in frontTires) {
				if (TireAngle > (MAX_ANGLE * -1)){
					tire.transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y - (TireTurnSpeed * Time.deltaTime), 0f);
					TireAngle -= TireTurnSpeed * Time.deltaTime;
				}
			}
		}
		
	}
}
