using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoatScript : MonoBehaviour {
	public int _damage = 1;
	public float _damageDelay = 4f;

	bool _canDamage = true;

	void OnCollisionEnter2D(Collision2D coll) {
	        if (_canDamage && coll.gameObject.tag == "Boat"){
	        	Health boatHealth = coll.gameObject.GetComponent<Health>();
	        	if(!boatHealth) return;
		_canDamage = false;
	        	boatHealth.Hit(_damage);
	        	StartCoroutine(StartDelay());
	        }
	}

	IEnumerator StartDelay(){
		yield return new WaitForSeconds(_damageDelay);
		_canDamage = true;
	}
}
