using UnityEngine;
using System.Collections;

public class LightSaber : MonoBehaviour {
	
	LineRenderer lineRend;
	BoxCollider2D collider;
	ParticleSystem particleSystem;
	public Transform startPos;
	public Transform endPos;
	
	private float textureOffset = 0f;
	public bool isBeamEnabled;
	private Vector3 endPosExtendedPos;
	private float timeLeft = 5.0f;

	// Use this for initialization
	void Awake () 
	{
		lineRend = GetComponent<LineRenderer>();
		endPosExtendedPos = endPos.localPosition;
		collider = GetComponent<BoxCollider2D>();
		particleSystem = GetComponent<ParticleSystem>();
		particleSystem.enableEmission = false;
		collider.enabled = false;
		lineRend.enabled = false;
	}
	
	void Update () 
	{
		//extend the line//
		if(isBeamEnabled && isTimerCorrect())
		{
			endPos.localPosition = Vector3.Lerp(endPos.localPosition, endPosExtendedPos, Time.deltaTime*5f);
			collider.enabled = true;
			lineRend.enabled = true;
			particleSystem.enableEmission = true;
		}
		//hide line//
		else
		{
			endPos.localPosition = Vector3.Lerp(endPos.localPosition, startPos.localPosition, Time.deltaTime*5f);
			collider.enabled = false;
			particleSystem.enableEmission = false;
		}
		
		//update line positions//
		lineRend.SetPosition(0,startPos.position);
		lineRend.SetPosition(1,endPos.position);

		//pan texture//
		textureOffset -= Time.deltaTime*2f;
		if(textureOffset < -10f)
		{
			textureOffset += 10f;
		}
		lineRend.sharedMaterials[1].SetTextureOffset("_MainTex",new Vector2(textureOffset,0f));
	}

	bool isTimerCorrect(){
		timeLeft -= Time.deltaTime;
		bool result = false;
		if(timeLeft >= 0){
			result = true;
		}
		return result;
	}

}
