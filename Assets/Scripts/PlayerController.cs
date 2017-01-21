using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// variable que incrementa la relación pulsación-distancia de la bala
	public int increment = 5;

    public GameObject scope;
	public GameObject stone;
	public GameObject boat;

	public GameObject begin;
	public GameObject end;


    public enum Side
    {
        Left,
        Right,
    }

	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = boat.GetComponent<BoxCollider2D>();

	}

	public void moveUp()
	{
		transform.Translate(Vector3.up * Time.deltaTime * increment);
	}

	public void moveDown()
	{
		transform.Translate(Vector3.down * Time.deltaTime * increment);
	}

	public void jump()
	{
		collider.isTrigger = true;
	}

	public void notJump()
	{
		collider.isTrigger = false;
	}

	public void shoot(float strength)
	{
		// vectores de distancia mínima y máxima
        Vector2 minDistance = begin.transform.position - transform.position;
        Vector2 maxDistance = end.transform.position - transform.position;

		// obtenemos un vector director * fuerza
		Vector2 shoot = minDistance;
		shoot = shoot * strength;

		if (Mathf.Abs(shoot.x) > Mathf.Abs(maxDistance.x))
			shoot = maxDistance;
		if (Mathf.Abs(shoot.x) < Mathf.Abs(minDistance.x))
			shoot = minDistance;

		//Debug.Log("Shoot coords: " + shoot);
		//Debug.Log("Max coords: " + maxDistance);

		shoot.x = transform.position.x + shoot.x;
		shoot.y = transform.position.y;

        WaveManager.Instance.SpawnWave(shoot);

	}

    public void SetScope(float strength)
    {
        // vectores de distancia mínima y máxima
        Vector2 minDistance = begin.transform.position - transform.position;
        Vector2 maxDistance = end.transform.position - transform.position;

        // obtenemos un vector director * fuerza
        Vector2 shoot = minDistance;
        shoot = shoot * strength;


        if (Mathf.Abs(shoot.x) > Mathf.Abs(maxDistance.x))
            shoot = maxDistance;
        if (Mathf.Abs(shoot.x) < Mathf.Abs(minDistance.x))
            shoot = minDistance;

        shoot.x = transform.position.x + shoot.x;
        shoot.y = transform.position.y;

        scope.transform.position = shoot;
    }

    public GameObject GetScope()
    {
        return scope;
    }

	public void shootFixed()
	{
		// vectores de distancia mínima y máxima
		Vector2 dir = boat.transform.localPosition - transform.localPosition;

		// obtenemos un vector director * fuerza
		Vector2 shoot = dir.normalized;
		shoot = shoot * dir.magnitude / 2;

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
