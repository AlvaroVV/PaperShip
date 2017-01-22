using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControllerXBOX : MonoBehaviour {

	private PlayerController Player;

	public GameObject _wavePrefab;

	public string axisControl;
	public float axisThreshold = .25f;
	public string ButtonShoot;

	private float _timePrepareForShoot;

	bool firePressed = false;

	public float _shootingForce = 2f;
	public Transform _initialHitPosition;
	public Transform _maxHitPosition;

	public Transform _boat;

	public bool _leftPlayer = false;

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
			Player.GetScope().transform.position = _initialHitPosition.position;
			Player.GetScope().SetActive(true);
		}

		if (Input.GetButton(ButtonShoot))
		{
			_timePrepareForShoot += Time.deltaTime;
            if (_leftPlayer)
            {
                Player.GetScope().transform.position = _initialHitPosition.position + Vector3.right * _timePrepareForShoot * _shootingForce;
                Player.GetScope().transform.position = new Vector3(Mathf.Clamp(Player.GetScope().transform.position.x, _initialHitPosition.position.x, _boat.position.x), Player.GetScope().transform.position.y, Player.GetScope().transform.position.z);
            }
            else
            {
                Player.GetScope().transform.position = _initialHitPosition.position + Vector3.left * _timePrepareForShoot * _shootingForce;
                Player.GetScope().transform.position = new Vector3(Mathf.Clamp(Player.GetScope().transform.position.x, _boat.position.x, _initialHitPosition.position.x), Player.GetScope().transform.position.y, Player.GetScope().transform.position.z);

            }

            // Player.SetScope(TimeToShoot);_bo
        }

        if (Input.GetButtonUp(ButtonShoot))
		{
			// Player.shoot(TimeToShoot);
			// TimeToShoot = 0.0f;
			_timePrepareForShoot = 0.0f;
			Player.GetScope().SetActive(false);

			Instantiate(_wavePrefab, Player.GetScope().transform.position, _wavePrefab.transform.rotation);

			// Player.GetScope().transform.position = _initialHitPosition.position;
		}
	}
}
