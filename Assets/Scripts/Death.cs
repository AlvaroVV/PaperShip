using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Health>().OnHealthChanged += CheckIsDead;
	}

	void CheckIsDead(int health){
		if(health <= 0){
			Debug.Log( gameObject.name + " is dead");
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
