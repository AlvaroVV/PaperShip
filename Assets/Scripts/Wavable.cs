using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavable : MonoBehaviour {

	//Velocidad máxima del objeto
	public float _maxVelocity = 20f;

	public float _maxAngularVelocity = 20f;

	//Fricción del agua
	public float _waterFriction = .1f;

	Rigidbody2D _rb;

	void Start(){
		_rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		LimitVelocity();
		ApplyWaterFriction();

		// LimitAngularVelocity();
	}

	//Limita la velocidad del objeto a una _maxVelocity
	void LimitVelocity(){
		// Vector2 velocity = _rb.velocity;
		float sqrMaxVelocity = _maxVelocity * _maxVelocity; //TODO: pasar a variable de clase
		if(_rb.velocity.sqrMagnitude > sqrMaxVelocity) {
		        _rb.velocity = _rb.velocity.normalized * _maxVelocity;
		}
	}

	//Limita la velocidad angular del objeto a una _maxVelocity
	void LimitAngularVelocity(){
		float angularVelocity = _rb.angularVelocity;

		Debug.Log("angular velocity = " + angularVelocity);

		if(Mathf.Abs(angularVelocity) > _maxAngularVelocity){
			_rb.angularVelocity = Mathf.Sign( angularVelocity) * _maxAngularVelocity;
		}
		Debug.Log("limited angular velocity = " + angularVelocity);

	}

	//Aplica una friccion simulada del agua
	void ApplyWaterFriction(){
		float velocityLength =  _rb.velocity.magnitude;
		if( velocityLength > _waterFriction) {
		        velocityLength -= _waterFriction;
		}
		else{
			velocityLength = 0;
		}
		_rb.velocity =  _rb.velocity.normalized * velocityLength;
	}
}
