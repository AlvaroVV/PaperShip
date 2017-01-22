using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartAnimation : MonoBehaviour {

	public GameObject _boat;
	public GameObject _playerLeft;
	public GameObject _playerRight;

	public Transform _boatTarget;
	public Transform _playerLeftTarget;
	public Transform _playerRightTarget;

	Vector3 _boatInitialPos;
	Vector3 _playerLeftInitialPos;
	Vector3 _playerRightInitialPos;

	public float _boatSpeed = 3;
	public float _playerSpeed = 4;

	SpawnerPool spawner;

	InputPC inputPC;
	InputAndroid inputAndroid;

	void Start(){
		_boatInitialPos = _boat.transform.position;
		_playerLeftInitialPos = _playerLeft.transform.position;
		_playerRightInitialPos = _playerRight.transform.position;
		//StartAnimation();
	}

	public void StartAnimation(){

		_boat.transform.position = _boatInitialPos;
		_playerLeft.transform.position = _playerLeftInitialPos;
		_playerRight.transform.position = _playerRightInitialPos;


		_boat.GetComponent<Collider2D>().enabled = false;
		spawner = GameObject.FindObjectOfType<SpawnerPool>();

		GameManager.Instance.DisableInput();

		StartCoroutine(AnimationCycle());
	}

	void EndAnimation(){
		_boat.GetComponent<Collider2D>().enabled = true;
		GameManager.Instance.EnableInput();
		GameManager.Instance.GameReady();
	}

	IEnumerator AnimationCycle(){
		yield return new WaitForSeconds(1f);

		while (_boat.transform.position.y < _boatTarget.position.y){
			_boat.transform.Translate(Vector2.up * _boatSpeed * Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds(.2f);

		 while (_playerRight.transform.position.y < _playerRightTarget.position.y)
		{
			_playerRight.transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds(.2f);


		while(_playerLeft.transform.position.y < _playerLeftTarget.position.y){
			_playerLeft.transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime);
			yield return null;
		}


		yield return new WaitForSeconds(1f);
		// EndAnimation();
		_boat.GetComponent<Collider2D>().enabled = true;
		GameManager.Instance.EnableInput();
		GameManager.Instance.GameReady();

		yield return null;
	}
}
