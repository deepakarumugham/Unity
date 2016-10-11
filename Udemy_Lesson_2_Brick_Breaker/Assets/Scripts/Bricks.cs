using UnityEngine;
using System.Collections;

public abstract class Bricks : MonoBehaviour {

	abstract public void SetFlower(GameObject bonus);
	public GameObject blast;
	public Sprite[] hitSprites;

	protected void Blast(){
		GameObject blastObject = Instantiate (blast, transform.position, Quaternion.identity) as GameObject;
		Destroy (blastObject, blastObject.GetComponent<ParticleSystem>().duration * 2f);
	}
}
