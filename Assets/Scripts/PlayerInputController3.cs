using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController3 : MonoBehaviour
{

	private PlayerController Player;

	public KeyCode ButtonUp;
	public KeyCode ButtonDown;

	public float strength;

	/* Variables de control de stone */
	private Vector2 startPos;
	private Vector2 direction;
	private bool movementDone;
	
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

		// Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			// Capturamos los movimientos del dedo en la pantalla
			switch (touch.phase)
			{
				// Guardamos la posición inicial
				case TouchPhase.Began:
					startPos = touch.position;
					movementDone = false;
					break;
					
				// Calculamos la dirección restando la posición actual con la inicial
				case TouchPhase.Moved:
					direction = touch.position - startPos;
					break;
					
				// Cuando detectamos la posición final activamos la direccion
				case TouchPhase.Ended:
					movementDone = true;
					break;
			}
		}
		if (movementDone)
		{
			// Usamos la dirección opuesta a la detectada para calcular la aparición de la piedra usando su magnitud
			Player.shootDir(direction.magnitude, -direction);
		}
	}
}
