using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SpawnWave(Vector2 position, float strength){
		Debug.Log("Wave on " + position + " with strength " + strength);
	}
}
