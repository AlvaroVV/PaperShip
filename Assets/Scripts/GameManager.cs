using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

private static GameManager gameManager;


	void Awake(){
		gameManager = this;
	}

	void Start(){
		boat = GameObject.FindGameObjectWithTag("Boat");

	}

	public static GameManager Instance{
		get{
			return gameManager;
		}
	}
	public LevelStartAnimation levelStartAnimation;

	GameObject boat;


	public void EnableInput(){
		if (Application.platform == RuntimePlatform.Android){
			GetComponent<InputAndroid>().enabled = true;
		}
		else{
			GetComponent<InputPC>().enabled = true;
		}
	}

	public void DisableInput(){
		if (Application.platform == RuntimePlatform.Android){
			GetComponent<InputAndroid>().enabled = false;
		}
		else{
			GetComponent<InputPC>().enabled = false;
		}
	}

	public void StartGame(){
		boat.SetActive(true);
		boat.GetComponent<Collider2D>().enabled = true;
		boat.GetComponent<Rigidbody2D>().isKinematic = false;

		boat.GetComponent<Health>().Restart();
		levelStartAnimation.StartAnimation();
	}

	public void GameReady(){
		Debug.Log("game ready");
		SpawnerPool spawnerPool = GameObject.FindObjectOfType<SpawnerPool>();
		spawnerPool.BeginSpawns();
	}

	public void GameOver(bool isPlayerDead){
		SpawnerPool spawnerPool = GameObject.FindObjectOfType<SpawnerPool>();
		spawnerPool.SetFinishLoop(true);

		boat.GetComponent<Collider2D>().enabled = false;
		boat.GetComponent<Rigidbody2D>().isKinematic = true;


		UIMenuManager uIMenuManager = GameObject.FindObjectOfType<UIMenuManager>();

		if(isPlayerDead){
			uIMenuManager.ShowGameOver();
			uIMenuManager.HideTitle();
		}
		else{
			uIMenuManager.HideGameOver();
			uIMenuManager.ShowTitle();
		}
		uIMenuManager.ShowMenu();
	}

}
