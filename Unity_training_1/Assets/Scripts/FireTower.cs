using UnityEngine;
using System.Collections;

public class FireTower : MonoBehaviour {
	Light light;
	LineRenderer gunLine;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	public float range = 1f;
	AudioSource gunShoot;
	// Use this for initialization
	void Awake () {
		light = GetComponent<Light> ();
		gunLine = GetComponent<LineRenderer> ();
		shootableMask = LayerMask.GetMask ("Shootable");
		gunShoot = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			gunShoot.Play();
			light.enabled = true;
			gunLine.enabled = true;
			Shoot();
		} else {
			light.enabled = false;
			gunLine.enabled = false;
		}
	}

	void Shoot(){
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		gunLine.SetPosition (0, transform.position);

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			Debug.Log( shootHit.collider.gameObject.name );
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (20, shootHit.point);
			}
			gunLine.SetPosition (1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}
