using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	public WaveManager _waveManager;

	void Start () {
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			_waveManager.SpawnWave( GetPoint());
		}
	}

	Vector3 GetPoint(){
		Vector3 point = Vector3.zero;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)){
			point = hit.point;
		}

		return point;
	}
}
