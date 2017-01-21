using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private Sprite sprite;
    private SpriteRenderer spriteRenderer;

    //Propiedades Pixels
    private float _pixelWidth;
    private float _pixelHeight;

    //Propiedades en Unity
    private float _unityWidth;
    private float _unityHeigth;

    //Porpiedades tamaño en unity;
    private float _width;
    private float _height;

    private float pixel2Unity;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;

        _pixelWidth = sprite.rect.width;
        _pixelHeight = sprite.rect.height;

        pixel2Unity = _pixelWidth / sprite.bounds.size.x; 

        _unityWidth = _pixelWidth / pixel2Unity;
        _unityHeigth = _pixelHeight /pixel2Unity;

        _width = spriteRenderer.bounds.size.x;
        _height = spriteRenderer.bounds.size.y;
        
        /*
        Debug.Log("_pixelWidth ->" + _pixelWidth);
        Debug.Log("_pixelHeigth ->" + _pixelHeight);
        Debug.Log("_pixel2Unity ->" + pixel2Unity);
        Debug.Log("_unityWidth ->" + _width);
        Debug.Log("_unityHeight ->" + _height);
        */

    }
	
    public float GetPixelHeight()
    {

        return _pixelHeight;
    }

    public float getPixelWidth()
    {
        return _pixelWidth;
    }

    public float GetUnityWidth()
    {
        return _unityWidth;
    }

    public float GetUnityHeight()
    {
        return _unityWidth;
    }

    public float GetHeight()
    {
        return _height;
    }

    public float GetWidth()
    {
        return _width;
    }

        
}
