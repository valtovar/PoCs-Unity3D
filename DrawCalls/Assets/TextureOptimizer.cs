using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureOptimizer : MonoBehaviour 
{
	public List<GameObject> gameObjects;
	public Material refMaterial;

	void Start () 
	{
		Material newMat = new Material (refMaterial);
		Texture2D packedTexture = new Texture2D (1024, 1024);

		Texture2D [] tmpTextures = new Texture2D[gameObjects.Count];
		for ( int i = 0; i < gameObjects.Count; i++ )
			tmpTextures[i] = gameObjects[i].renderer.material.mainTexture as Texture2D;

		Rect [] uvs = packedTexture.PackTextures (tmpTextures, 0, 1024);
		newMat.mainTexture = packedTexture;

		Vector2[] uva, uvb;
		for ( int i = 0; i < gameObjects.Count; i++ )
		{
			gameObjects[i].renderer.material = newMat;
			uva = gameObjects[i].GetComponent<MeshFilter>().mesh.uv;
			uvb = new Vector2[uva.Length];
			for ( int j = 0; j < uva.Length; j++ )
			{
				uvb[j] = new Vector2 ( ( uva[j].x * uvs[i].width ) + uvs[i].x, ( uva[j].y * uvs[i].height ) + uvs[i].y );
			}

			gameObjects[i].GetComponent<MeshFilter>().mesh.uv = uvb;
		}
	}
}
