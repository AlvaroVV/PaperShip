using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public float speed = 1;
    public List<GameObject> ObjectsToChoose;
    private GameObject obj;

    private float _maxYSpawn;
    private Camera _maincamera;
    private Transform _mainCameraTransform;


	// Use this for initialization
	void Start () {
        _maincamera = Camera.main;
        _mainCameraTransform = _maincamera.transform;

        _maxYSpawn = _mainCameraTransform.position.y - _maincamera.orthographicSize;
    }

	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < _maxYSpawn)
            gameObject.SetActive(false);
    }

    void OnEnable()
    {
        obj = Instantiate(ObjectsToChoose[Random.Range(0, ObjectsToChoose.Count )], transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }

    void OnDisable()
    {
        Destroy(obj);
    }
}
