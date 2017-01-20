using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int increment;

	public GameObject stone;

	public GameObject begin;
	public GameObject end;

	// Use this for initialization
	void Start () {
		increment = 5;
	}
	
	public void moveUp()
	{
		transform.Translate(Vector3.up * Time.deltaTime * increment);
	}

	public void moveDown()
	{
		transform.Translate(Vector3.down * Time.deltaTime * increment);
	}

	public void shoot(float strength)
	{

		float MIN_STRENGTH = begin.transform.position.x;
		float MAX_STRENGTH = end.transform.position.x;

		Debug.Log("Position begin: " + begin.transform.position);
		Debug.Log("Position end: " + end.transform.position);
		float RealStrength = MIN_STRENGTH + strength * increment;

		if (RealStrength > MAX_STRENGTH)
			RealStrength = MAX_STRENGTH;

		GameObject.Instantiate(stone, new Vector3(transform.position.x + RealStrength, transform.position.y), Quaternion.identity);
	}
}
