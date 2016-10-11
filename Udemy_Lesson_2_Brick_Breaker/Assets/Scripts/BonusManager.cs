using UnityEngine;
using System.Collections;

public class BonusManager : MonoBehaviour {

	public GameObject flower;
	private GameObject[] bricks;

	void Start () {
		bricks = GameObject.FindGameObjectsWithTag ("brick");
		int max = bricks.Length;
		int bonuses = max / 2;

		for(int i = 0 ; i < bonuses; i++){
			int random = Random.Range (0, max - 1);
			GameObject brick = bricks [random];
			Bricks brickType = brick.GetComponent<Bricks> ();
			brickType.SetFlower (flower);
		}
	}
	
}
