using UnityEngine;
using System.Collections;

public class OneHit : Bricks {

	private GameObject bonus;
	// Use this for initialization
	void Start () {
		this.bonus = null;
	}

	override
	public void SetFlower(GameObject bonus){
		this.bonus = bonus;
	}
	
	public void OnCollisionEnter2D(Collision2D collision){
		HandleHit ();
	}

	public void OnTriggerEnter2D(Collider2D trigger){
		HandleHit ();
	}

	private void HandleHit(){
		
		if (this.bonus != null) {
			this.bonus.transform.position = transform.position;
			this.bonus.SetActive(true);
			this.bonus = null;
		}
		// blast.GetComponent<ParticleSystem>().startColor = this.gameObject.GetComponent<SpriteRenderer> ().color;
		Blast();
		Destroy (gameObject);
	}
}
