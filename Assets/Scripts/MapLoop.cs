using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoop : MonoBehaviour {


    public float _speed = 1;
    public List<Map> maps;

    private Map currentMap;

    //Característica de la camara
    private Camera mainCamera;
    private float _camHeight;
    private float _camWidth;

    
    

	// Use this for initialization
	void Start () {

        mainCamera = Camera.main;
        _camHeight = 2f * mainCamera.orthographicSize;
        _camWidth = _camHeight * mainCamera.aspect;

        currentMap = maps[0];

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        currentMap.transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if(currentMap.transform.position.y + currentMap.GetHeigth()/2 <mainCamera.transform.position.y -_camHeight)
        {
            currentMap.transform.position = new Vector3(currentMap.transform.position.x, mainCamera.transform.position.y + _camHeight + currentMap.GetHeigth()/2, currentMap.transform.position.z);
        }
		
	}
}
