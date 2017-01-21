using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Mueve el barco al punto _targetY
public class BoatController : MonoBehaviour {

	public float _targetY = 0f;
	public float _speed = 1f;


	void FixedUpdate () {
		float step = _speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, _targetY), step);
	}


}
