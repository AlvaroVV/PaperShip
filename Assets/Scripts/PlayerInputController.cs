using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {

	private PlayerController Player;

	public KeyCode ButtonUp;
	public KeyCode ButtonDown;
	public KeyCode ButtonShoot;

	private float TimeToShoot;


	// Use this for initialization
	void Start () {
		Player = GetComponent<PlayerController>();
	}
	

	void Update()
	{
		if (Input.GetKey(ButtonUp))
		{
			Player.moveUp();
		}

		if (Input.GetKey(ButtonDown))
		{
			Player.moveDown();
		}
        if(Input.GetKeyDown(ButtonShoot))
        {
            Player.GetScope().SetActive(true);
        }

		if (Input.GetKey(ButtonShoot))
		{
			TimeToShoot += Time.deltaTime;
            Player.SetScope(TimeToShoot);
		}

		if (Input.GetKeyUp(ButtonShoot))
		{
			Player.shoot(TimeToShoot);
			TimeToShoot = 0.0f;
            Player.GetScope().SetActive(false);
        }
	}
}
