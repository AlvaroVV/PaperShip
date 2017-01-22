﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public Text text;
	public delegate void HealthEvent(int health);
	public HealthEvent OnHealthChanged;

	public int _health = 3;
    public int _timeInvencible = 2;
    private bool invencible = false;

    private int currentHP;
    private AudioSource audio;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();
        currentHP = _health;
        text.text = currentHP + "/" + _health;
    }

	public void Hit(int damage){
        if(!invencible)
        {
            invencible = true;
		    currentHP -= damage;
            anim.SetTrigger("Vida" + currentHP);
            text.text = currentHP + "/" + _health;
            audio.Play();
            if (currentHP <= 0)
            {
                Debug.Log("MUERTO");
				TimeControllManager.Instance.FinishGame();
            }

            StartCoroutine(TimeInvencible());
		}
	}

    IEnumerator TimeInvencible()
    {
        
        yield return new WaitForSeconds(_timeInvencible);
        invencible = false;
    }


}
