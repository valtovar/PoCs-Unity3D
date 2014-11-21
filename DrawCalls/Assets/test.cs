using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Material t = new Material (renderer.sharedMaterial);
		t.mainTextureOffset = new Vector2 (10, 10);
		renderer.sharedMaterial = t;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
