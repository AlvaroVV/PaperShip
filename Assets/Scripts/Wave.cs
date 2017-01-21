using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public int _numWaves = 10;
	float _waveRadius = .1f;
	public float _scaleWave = 1;
	public float _timeBetweenScale = .05f;
	public float _waveForceScale = .1f;
	public float _strengthForceScale = 4f;

	List<GameObject> wavedGO = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}

	public void StartWave(){
		// Debug.Log("start wave with strength" );
		StartCoroutine(ExpandWave());
	}

	IEnumerator ExpandWave(){

		int nWaves = _numWaves;
		while(nWaves > 0){

			//Set new scale for wave
			_waveRadius += _scaleWave;
			Vector3 newScale = new Vector3(_waveRadius, 1, _waveRadius);
			gameObject.transform.localScale = newScale;

			//Check wave overlap
			Collider2D[] waveColls = Physics2D.OverlapCircleAll(transform.position, _waveRadius, 1 << LayerMask.NameToLayer("Wavable"));

			foreach(Collider2D coll in waveColls){
				if(!wavedGO.Contains(coll.gameObject)){
					MoveByWave(coll.gameObject, (float)nWaves /(float)_numWaves);
					wavedGO.Add(coll.gameObject);
				}
			}

			nWaves--;
			yield return new WaitForSeconds(_timeBetweenScale);
		}
		Destroy(gameObject, 1f);
		yield return null;
	}

	void MoveByWave(GameObject go, float strength){
		BoatController boatController = go.GetComponent<BoatController>();
		if(boatController != null){
			Vector3 waveForce = go.transform.position - transform.position;
			waveForce.Normalize();

			Vector2 totalForce = new Vector2(waveForce.x, waveForce.y ) * _waveForceScale * strength *_strengthForceScale;

			Debug.Log("force = " + waveForce + " forceScale " + _waveForceScale + " strength + " + strength);
			boatController.AddImpulse(totalForce);
		}
		else{
			Debug.Log("not a boat");
		}
	}

}
