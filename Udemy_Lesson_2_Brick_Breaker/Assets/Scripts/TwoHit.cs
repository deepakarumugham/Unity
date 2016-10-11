using UnityEngine;
using System.Collections;

public class TwoHit : Bricks {

	private int hitCount;
	private GameObject bonus;
	// Use this for initialization
	void Start () {
		hitCount = 0;
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
		hitCount++;
		if(hitCount == 1){
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = hitSprites[hitCount - 1];
		}else if (hitCount == 2) {
			if (this.bonus != null) {
				this.bonus.transform.position = transform.position;
				this.bonus.SetActive(true);
				this.bonus = null;
			}
			// blast.GetComponent<ParticleSystem>().startColor = this.gameObject.GetComponent<SpriteRenderer> ().color;
			Blast();
			Destroy (this.gameObject);
		}
	}

}
