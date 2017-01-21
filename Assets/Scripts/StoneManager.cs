using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour {

	public float lifetime = 2.0f;


	void Awake()
	{
		Destroy(gameObject, lifetime);
	}


	public void Shoot(Vector2 dir, float strength)
	{
		transform.Translate(dir * Time.deltaTime * strength);
	}
}
