using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController3 : MonoBehaviour
{

	private bool LeftPlayer;

	private PlayerController Player;
	public float strength;

	/* Variables de control de stone */
	private Vector2 startPos, endPos;
	private Vector2 direction;
	private bool movementDone;
	
	// Use this for initialization
	void Start()
	{
		if (Camera.main.WorldToViewportPoint(transform.position).x < 0.5f)
			LeftPlayer = true;
		else
			LeftPlayer = false;
		Player = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void FixedUpdate()
	{

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
					endPos = touch.position;
					
					/* 
					Si nuestro jugador es el de la izquierda prohibimos el disparo hacia la izquierda 
					Si es el de la derecha prohibimos el disparo a la derecha
					*/
					if (LeftPlayer)
					{
						if (endPos.x < startPos.x)
							movementDone = true;
					} else
					{
						if (endPos.x > startPos.x)
							movementDone = true;
					}
					break;
			}
		}
		if (movementDone)
		{
			// Usamos la dirección opuesta a la detectada para calcular la aparición de la piedra usando su magnitud
			float magnitude = direction.magnitude;
			direction = -direction;
			Player.shootDir(direction.magnitude, direction.normalized);
		}
	}
}
