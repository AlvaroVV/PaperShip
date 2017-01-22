using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	/*
	private enum UIState
	{
		Playing,
		Finished
	}

	private UIState currentState;*/

	public GameObject _mainPanel;
	public GameObject _gameFinishedPanel;

	private static UIManager instance;
	public static UIManager Instance
	{
		get
		{
			return instance;
		}
	}


	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		_mainPanel.SetActive(true);
		_gameFinishedPanel.SetActive(false);
	}

	public void ShowFinalPanel()
	{
		_gameFinishedPanel.SetActive(true);
	}


}
