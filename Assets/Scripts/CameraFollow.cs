using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Ship;
    public float SpeedFollow = 1;
    [Range(0,50)]
    public float TopPer;
    [Range(0, 50)]
    public float BotPer;


    //Porpiedades de la cámara
    private Camera _camera;
    private float _camHeight;
    private float _camwidth;

    //Limites
    private float _topLimit;
    private float _botLimit;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();
        _camHeight = 2f * _camera.orthographicSize;
        _camwidth = _camHeight * _camera.aspect;

        _topLimit = (_camHeight / 2) * _topLimit;
        _botLimit = (_camHeight / 2) * _botLimit;



    }
	
	// Update is called once per frame
	void Update () {
        if ((Ship.transform.position.y >= transform.position.y + _topLimit) || (Ship.transform.position.y <= transform.position.y - _botLimit))
            FollowShip();
	}

    void FollowShip()
    {
        Vector3 interpolate = Vector3.Lerp(transform.position, Ship.transform.position, Time.deltaTime * SpeedFollow);
        transform.position = new Vector3(transform.position.x, interpolate.y, transform.position.z);
    }

}
