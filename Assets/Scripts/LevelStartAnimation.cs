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

	public float _boatSpeed = 3;
	public float _playerSpeed = 4;

	SpawnerPool spawner;

	InputPC inputPC;
	InputAndroid inputAndroid;

	void Start(){
		//StartAnimation();
	}

	public void StartAnimation(){
		_boat.GetComponent<Collider2D>().enabled = false;
		spawner = GameObject.FindObjectOfType<SpawnerPool>();

		inputPC = GameObject.FindObjectOfType<InputPC>();

		if(inputPC != null){
			inputPC.enabled = false;
		}
		else{
			inputAndroid = GameObject.FindObjectOfType<InputAndroid>();
			inputAndroid.enabled = false;
		}

		StartCoroutine(AnimationCycle());
	}

	IEnumerator AnimationCycle(){
		yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(.2f);

        while (_playerRight.transform.position.y < _playerRightTarget.position.y)
        {
            _playerRight.transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime);
            yield return null;
        }

        while (_boat.transform.position.y < _boatTarget.position.y){
			_boat.transform.Translate(Vector2.up * _boatSpeed * Time.deltaTime);
			yield return null;
		}


		yield return new WaitForSeconds(.2f);


		while(_playerLeft.transform.position.y < _playerLeftTarget.position.y){
			_playerLeft.transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime);
			yield return null;
		}


		yield return new WaitForSeconds(1f);
		_boat.GetComponent<Collider2D>().enabled = true;


		if(inputPC != null){
			inputPC.enabled = true;
		}
		else{
			inputAndroid.enabled = true;
		}
		spawner.BeginSpawns();

		yield return null;
	}
}
