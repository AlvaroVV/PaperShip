using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController2 : MonoBehaviour
{

	private PlayerController Player;

	public KeyCode ButtonUp;
	public KeyCode ButtonDown;
	public KeyCode ButtonShoot;

	private float TimeToShoot;


	// Use this for initialization
	void Start()
	{
		Player = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void FixedUpdate()
	{
		if (Input.GetKey(ButtonUp))
		{
			Player.moveUp();
		}

		if (Input.GetKey(ButtonDown))
		{
			Player.moveDown();
		}

		if (Input.GetKeyUp(ButtonShoot))
		{
			Player.shootFixed();
			TimeToShoot = 0.0f;
		}
	}
}
