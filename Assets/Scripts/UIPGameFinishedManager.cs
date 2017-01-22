using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPGameFinishedManager : MonoBehaviour {

	public Button _restartGameButton;
	public Button _exitGameButton;

	// Use this for initialization
	void Awake()
	{
		SetUpFunctionality();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void SetUpFunctionality()
	{
		if (_restartGameButton != null)
		{
			_restartGameButton.onClick.AddListener(delegate {
			});
		}
		if (_exitGameButton != null)
		{
			_exitGameButton.onClick.AddListener(delegate {
				Debug.Log("Saliendo de la aplicación.");
				Application.Quit();
			});
		}
	}

}
