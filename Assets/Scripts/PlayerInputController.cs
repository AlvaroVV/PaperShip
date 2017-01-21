using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	private PlayerController controller1;
	private PlayerController controller2;

	public KeyCode ButtonUp1;
	public KeyCode ButtonDown1;
	public KeyCode ButtonShoot1;

	public KeyCode ButtonUp2;
	public KeyCode ButtonDown2;
	public KeyCode ButtonShoot2;

	public KeyCode ButtonJump;

	private float TimeToShoot1 = 1.0f;
	private float TimeToShoot2 = 1.0f;

	public float TimeToJump = 5.0f;
	public float TimeJumping = 5.0f;

	enum JumpState { DISABLED, ENABLED, JUMPING };

	private JumpState Jump = JumpState.ENABLED;
	private float TimeKeeper = 0.0f;


	// Use this for initialization
	void Start () {
		controller1 = player1.GetComponent<PlayerController>();
		controller2 = player2.GetComponent<PlayerController>();
	}
	

	void Update()
	{
		// Activamos el salto si superamos el tiempo de carga (TimeToJump)
		switch (Jump)
		{
			case JumpState.ENABLED:
				if (Input.GetKeyDown(ButtonJump))
				{
					Debug.Log("SALTANDO");
					Jump = JumpState.JUMPING;
					controller1.jump();
					TimeKeeper = 0.0f;
				}
				break;

			case JumpState.DISABLED:
				TimeKeeper += Time.deltaTime;
				if (TimeKeeper >= TimeToJump)
				{
					Jump = JumpState.ENABLED;
					Debug.Log("SALTO ACTIVADO");
				}
				break;

			case JumpState.JUMPING:
				TimeKeeper += Time.deltaTime;
				if (TimeKeeper >= TimeJumping)
				{
					Debug.Log("SALTO DESACTIVADO");
					Jump = JumpState.DISABLED;
					controller1.notJump();
					TimeKeeper = 0.0f;
				}
				break;
		}
		

		if (Input.GetKey(ButtonUp1))
		{
			controller1.moveUp();
		}

		if (Input.GetKey(ButtonDown1))
		{
			controller1.moveDown();
		}
        if(Input.GetKeyDown(ButtonShoot1))
        {
            controller1.GetScope().SetActive(true);
        }

		if (Input.GetKey(ButtonShoot1))
		{
			TimeToShoot1 += Time.deltaTime;
            controller1.SetScope(TimeToShoot1);
		}

		if (Input.GetKeyUp(ButtonShoot1))
		{
			controller1.shoot(TimeToShoot1);
			TimeToShoot1 = 1.0f;
            controller1.GetScope().SetActive(false);
        }


		if (Input.GetKey(ButtonUp2))
		{
			controller2.moveUp();
		}

		if (Input.GetKey(ButtonDown2))
		{
			controller2.moveDown();
		}
		if (Input.GetKeyDown(ButtonShoot2))
		{
			controller2.GetScope().SetActive(true);
		}

		if (Input.GetKey(ButtonShoot2))
		{
			TimeToShoot2 += Time.deltaTime;
			controller2.SetScope(TimeToShoot2);
		}

		if (Input.GetKeyUp(ButtonShoot2))
		{
			controller2.shoot(TimeToShoot2);
			TimeToShoot2 = 1.0f;
			controller2.GetScope().SetActive(false);
		}
	}
}
