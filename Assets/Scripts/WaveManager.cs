using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public GameObject _wavePrefab;

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
