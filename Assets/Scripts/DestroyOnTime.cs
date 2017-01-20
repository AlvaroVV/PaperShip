using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

	public float _timeToDestroy;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, _timeToDestroy);
	}
}
