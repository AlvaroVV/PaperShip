using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour {

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
        _cameraHeight = 2f * _camera.orthographicSize;
        _cameraWidth = _cameraHeight * _camera.aspect;
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
