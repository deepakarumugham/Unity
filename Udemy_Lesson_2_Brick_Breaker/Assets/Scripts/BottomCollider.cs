using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	private LevelManager levelManager;
	public void OnTriggerEnter2D(Collider2D trigger){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		if (trigger.gameObject.tag == "ball") {
			levelManager.loadLevel ("Level_1");
		} else {
			Destroy(trigger.gameObject);
		}
	}

}
