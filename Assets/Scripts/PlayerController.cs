using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// variable que incrementa la relación pulsación-distancia de la bala
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
		// vectores de distancia mínima y máxima
		Vector2 minDistance = begin.transform.localPosition - transform.localPosition;
		Vector2 maxDistance = end.transform.localPosition - transform.localPosition;

		// obtenemos un vector director * fuerza
		Vector2 shoot = minDistance.normalized;
		shoot = shoot * strength * increment;

		Debug.Log("Magnitud vector min: " + minDistance);
		Debug.Log("Magnitud vector max: " + maxDistance);
		Debug.Log("Magnitud shoot: " + shoot);

		if (shoot.magnitude > maxDistance.magnitude)
			shoot = maxDistance;
		if (shoot.magnitude < minDistance.magnitude)
			shoot = minDistance;

		shoot.x = transform.position.x + shoot.x;
		shoot.y = transform.position.y;

		GameObject stone2 = GameObject.Instantiate(stone, shoot, Quaternion.identity);
	}

	public void shootFixed()
	{

		float MIN_STRENGTH = begin.transform.position.x;

		float RealStrength = MIN_STRENGTH + increment;

		GameObject stone2 = GameObject.Instantiate(stone, new Vector3(RealStrength, transform.position.y, 0.0f), Quaternion.identity);
	}

	public void shootDir(float strength, Vector2 dir)
	{
		Vector2 FinalPos = dir * strength;

		float MIN_STRENGTH = begin.transform.position.x;
		float MAX_STRENGTH = end.transform.position.x;

		float RealStrength = MIN_STRENGTH + strength * increment;

		if (dir.x < MIN_STRENGTH)
			dir.x = MIN_STRENGTH;

		if (dir.y < MAX_STRENGTH)
			dir.y = MAX_STRENGTH;

		GameObject stone2 = GameObject.Instantiate(stone, dir * strength, Quaternion.identity);
	}

}
