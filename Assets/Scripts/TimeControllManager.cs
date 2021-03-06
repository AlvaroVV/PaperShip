﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControllManager : MonoBehaviour {

    public List<AudioClip> audios;
    public MapLoop mapLoop;
    private AudioSource audioSource;
	public SpawnerPool spawner;

	private static TimeControllManager instance;
	public static TimeControllManager Instance
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
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartControlTime());
	}

	private IEnumerator StartControlTime()
    {
        for(int i = 0; i<audios.Count-1; i++)
        {
            audioSource.clip = audios[i];
            audioSource.Play();
            yield return new WaitForSeconds(audios[i].length);
            mapLoop._speed += 1;

        }
        yield return null;

        audioSource.clip = audios[audios.Count - 1];
        audioSource.Play();
        audioSource.loop = true;
    }
}
