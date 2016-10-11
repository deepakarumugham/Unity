using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int health = 100;
	private bool isDead = false;

	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;
		
		health -= amount;
		
		if(health <= 0)
		{
			Destroy (gameObject, 0f);
		}
	}
}
