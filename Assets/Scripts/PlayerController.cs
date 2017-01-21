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

		if (Mathf.Abs(shoot.x) > Mathf.Abs(maxDistance.x))
			shoot = maxDistance;
		if (Mathf.Abs(shoot.x) < Mathf.Abs(minDistance.x))
			shoot = minDistance;

		shoot.x = transform.position.x + shoot.x;
		shoot.y = transform.position.y;

		GameObject stone2 = GameObject.Instantiate(stone, shoot, Quaternion.identity);
	}

	public void shootFixed()
	{

		// vectores de distancia mínima y máxima
		Vector2 dir = begin.transform.localPosition - transform.localPosition;

		// obtenemos un vector director * fuerza
		Vector2 shoot = dir.normalized;
		shoot = shoot * increment;

		shoot.x = transform.position.x + shoot.x;
		shoot.y = transform.position.y;

		GameObject.Instantiate(stone, shoot, Quaternion.identity);
	}

	public void shootDir(float strength, Vector2 dir)
	{

		// vectores de distancia mínima y máxima en los dos ejes
		Vector2 minDistanceX = begin.transform.localPosition - transform.localPosition;
		Vector2 maxDistanceXY = end.transform.localPosition - transform.localPosition;
		
		// multiplicamos el vector director * fuerza
		Vector2 shoot = dir;
		shoot = shoot * strength * increment;

		// calculamos los vectores de coordenadas
		Vector2 shootY = new Vector2(shoot.y, 0.0f);
		Vector2 shootX = new Vector2(shoot.x, 0.0f);

		// Aseguramos distancia máxima ejes XY
		if (Mathf.Abs(shoot.x) > Mathf.Abs(maxDistanceXY.x))
			shoot.x = maxDistanceXY.x;
		if (Mathf.Abs(shoot.y) > Mathf.Abs(maxDistanceXY.y))
			shoot.y = maxDistanceXY.y;

		// Aseguramos distancia mínima en eje x
		if (Mathf.Abs(shoot.x) < Mathf.Abs(minDistanceX.x))
			shoot.x = minDistanceX.x;

		shoot.x = transform.position.x + shoot.x;
		shoot.y = transform.position.y + shoot.y;

		GameObject.Instantiate(stone, shoot, Quaternion.identity);
	}
}
