using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

	GameObject player;
	NavMeshAgent agent;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (player.transform.position);
	}
}
