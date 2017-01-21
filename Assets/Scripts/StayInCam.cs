using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInCam : MonoBehaviour {

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0);
		
	}
}
