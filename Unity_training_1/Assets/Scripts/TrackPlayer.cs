using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject enemy;
	public float spawnTime = 0.2f;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	

	void Spawn () {
		for (int i =0; i< spawnPoints.Length; i++){
			Instantiate (enemy, spawnPoints[i].position, spawnPoints[i].rotation);
		}
	}
}
