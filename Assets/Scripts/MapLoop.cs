using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoop : MonoBehaviour {


    public float _speed = 1;

    public List<Map> maps;

    private Map currentMap;
    private Map nextMap;

    //Característica de la camara
    private Camera mainCamera;
    private float _camHeight;
    private float _camWidth;

    
    

	// Use this for initialization
	void Start () {

        mainCamera = Camera.main;
        _camHeight = 2f * mainCamera.orthographicSize;
        _camWidth = _camHeight * mainCamera.aspect;

        PutMaps();

        currentMap = maps[0];
        currentMap.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - _camHeight/2 + currentMap.GetHeight()/2, 0);
        
       

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        MoveMap(currentMap);
        if (currentMap.transform.position.y + currentMap.GetHeight() / 2 <= mainCamera.transform.position.y + _camHeight / 2)
        {
            nextMap = maps[GetMap()];
            MoveMap(nextMap);
        }
        if(currentMap.transform.position.y + currentMap.GetHeight()/2 <=mainCamera.transform.position.y -_camHeight/2)
        {
            currentMap.transform.position = new Vector3(currentMap.transform.position.x,
                mainCamera.transform.position.y + _camHeight/2 + currentMap.GetHeight()/2,
                currentMap.transform.position.z);
            currentMap = nextMap;
        }
		
	}

    private void MoveMap(Map map)
    {
        map.transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void PutMaps()
    {
        for(int x = 0; x < maps.Count; x ++)
        {
            maps[x].transform.position = new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y + _camHeight/2 + maps[x].GetHeight()/2,0);
        }
    }

    private int GetMap()
    {
        int i = maps.IndexOf(currentMap);
        if (i == maps.Count - 1)
            i = 0;
        else
            i++;
        return i;
    }

    public Map GetCurrentMap()
    {
        return currentMap;
    }
}
