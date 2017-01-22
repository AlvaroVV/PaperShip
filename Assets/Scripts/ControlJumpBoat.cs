using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJumpBoat : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Boat"))
        {
            if (col.GetComponent<CircleCollider2D>().isTrigger)
                col.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
