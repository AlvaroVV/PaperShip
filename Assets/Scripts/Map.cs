using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public Texture texture;
   

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = texture;
        transform.localScale = new Vector3(texture.width, texture.height, 1);
    }
	
    public float GetHeigth()
    {
        return texture.height;
    }

    public float GetWidth()
    {
        return texture.width;
    }
}
