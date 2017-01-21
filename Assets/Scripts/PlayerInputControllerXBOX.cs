using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControllerXBOX : MonoBehaviour {

	private PlayerController Player;

	public string axisControl;
	public float axisThreshold = .25f;
	public string ButtonShoot;

	private float TimeToShoot;

	bool firePressed = false;

	// Use this for initialization
	void Start () {
		Player = GetComponent<PlayerController>();
	}


	void Update()
	{
		float axis = Input.GetAxis(axisControl);
		if(axis < -axisThreshold){
			Player.moveUp();

		}
		else if (axis > axisThreshold){
			Player.moveDown();
		}


		if(Input.GetButtonDown(ButtonShoot))
		{
			Player.GetScope().SetActive(true);
		}

		if (Input.GetButton(ButtonShoot))
		{
			TimeToShoot += Time.deltaTime;
			Player.SetScope(TimeToShoot);
		}

		if (Input.GetButtonUp(ButtonShoot))
		{
			Player.shoot(TimeToShoot);
			TimeToShoot = 0.0f;
			Player.GetScope().SetActive(false);
		}
	}
}
