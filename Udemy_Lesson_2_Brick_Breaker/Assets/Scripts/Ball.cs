using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]
public class Ball : MonoBehaviour {

	private PaddleMovement paddle;
	private Vector3 offset;
	private Rigidbody2D rigidBody;
	private static bool hasGameStarted;
	private AudioSource audioSource;
	private Transform cameraTransform;
	private Vector3 cameraInitialPos;
	public static int score;
	public float timeScale;
	public float fixedDeltaTime;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleMovement>();

		cameraTransform = Camera.main.transform;
		cameraInitialPos = cameraTransform.position;

		offset = this.transform.position - paddle.transform.position;
		rigidBody = this.GetComponent<Rigidbody2D> ();
		audioSource = this.GetComponent<AudioSource> ();
		hasGameStarted = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasGameStarted) {
			this.transform.position = paddle.transform.position + offset;
			if(Input.GetMouseButtonDown (0)){
				rigidBody.velocity = new Vector2(2f, 10f);
				hasGameStarted = true;
			}
		}

	}

	void PerformSlowMotion(){
		Time.timeScale = 0.5f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	void ResetTimeScale(){
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f;
	}
		
	void PerformCamZoomIn(Vector3 endPosition){
		Camera.main.transform.position = Vector3.Lerp (cameraInitialPos, endPosition, Time.timeScale);
	}

	public void OnCollisionEnter2D(Collision2D collision){
		audioSource.Play ();
		rigidBody.velocity += new Vector2 (Random.Range(0.05f, 0.2f), Random.Range(0.05f, 0.2f));
		if (collision.gameObject.tag == "brick") {
			score += 10;
		}

	}


}
