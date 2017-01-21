using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

	float _maxVelocity = 20f;
	float _waterFriction = .02f;
	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	public void AddImpulse(Vector2 force){
		rb.velocity = new Vector2(
			Mathf.Sign(force.x) * Mathf.Min(Mathf.Abs(force.x), _maxVelocity ),
			Mathf.Sign(force.y) * Mathf.Min(Mathf.Abs(force.y), _maxVelocity )
		 );
		Debug.Log("impulse " + force);
	}

	void FixedUpdate(){
		float signX = Mathf.Sign(rb.velocity.x);
		float absForceX = Mathf.Abs(rb.velocity.x);
		if (absForceX > _waterFriction){
			absForceX -= _waterFriction;
		}
		else{
			absForceX = 0f;
		}
		rb.velocity = new Vector3(signX * absForceX, rb.velocity.y, 0f);
	}
}
