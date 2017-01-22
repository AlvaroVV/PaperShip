using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour {

    //Resoluciones
    public float MaxFactorSize;
    public float MinFactorSize;

    public float widthReference =1366f;
    public float sizeReference = 3.7f;

    private static ResolutionManager instance;
    public static ResolutionManager Instance
    {
        get
        {
            return instance;
        }
    }

    private Camera _camera;
    private float _cameraWidth;
    private float _cameraHeight;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        _camera = Camera.main;

        _camera.orthographicSize = 1f / _camera.aspect * 20f / 2f;
        _cameraHeight = 2f * _camera.orthographicSize;
        _cameraWidth = _cameraHeight * _camera.aspect;

        Debug.Log(Screen.currentResolution.width);
        
    }
	
    public float GetCameraHeight()
    {
        return _cameraHeight;
    }

    public float GetCameraWidth()
    {
        return _cameraWidth;
    }

    public Vector3 GetCameraPosition()
    {
        return _camera.transform.position;
    }
}
