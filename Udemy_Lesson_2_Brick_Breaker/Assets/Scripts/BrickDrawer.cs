using UnityEngine;
using System.Collections;

public class BrickDrawer : MonoBehaviour {

	LineRenderer line;
	// Use this for initialization
	void Start () {
		line = transform.GetComponent<LineRenderer> ();
		line.SetVertexCount (5);
		line.SetPosition (0, new Vector3 (-1, 1, 0));
		line.SetPosition (1, new Vector3 (1, 1, 0));
		line.SetPosition (2, new Vector3 (1, -1, 0));
		line.SetPosition (3, new Vector3 (-1, -1, 0));
		line.SetPosition (4, new Vector3 (-1, 1, 0));
	}
	
}
