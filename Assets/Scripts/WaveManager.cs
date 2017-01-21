using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    private static WaveManager instance;
    public static WaveManager Instance
    {
        get
        {
            return instance;
        }
    }

	public GameObject _wavePrefab;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		if(!_wavePrefab){
			Debug.Log( "WaveManager not find Wave Prefab");
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void SpawnWave(Vector3 position){
		if(!_wavePrefab) return;
		GameObject waveGO = GameObject.Instantiate( _wavePrefab, position, _wavePrefab.transform.rotation) as GameObject;
		waveGO.GetComponent<Wave>().StartWave();
	}
}
