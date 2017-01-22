using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoatScript : MonoBehaviour {
	public int _damage = 1;
	public float _damageDelay = 4f;
   

	void OnCollisionEnter2D(Collision2D coll)
    {
	    if (coll.gameObject.tag == "Boat")
        {
	        Health boatHealth = coll.gameObject.GetComponent<Health>();
	        if(!boatHealth) return;		        
	        boatHealth.Hit(_damage);
	    }
	}


}
