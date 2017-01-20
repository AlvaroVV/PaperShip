using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	public WaveManager _waveManager;
	public float _waveStrength;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Vector2 spawnPosition = Input.mousePosition;
			_waveManager.SpawnWave( spawnPosition, _waveStrength);
		}
	}
}
