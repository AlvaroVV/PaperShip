using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public delegate void HealthEvent(int health);
	public HealthEvent OnHealthChanged;

	public int _health;

	public void Hit(int damage){
		_health -= damage;

		if(OnHealthChanged != null){
			OnHealthChanged(_health);
		}
	}
}
