using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Text text;
	public delegate void HealthEvent(int health);
	public HealthEvent OnHealthChanged;

	public int _health = 3;
	public float _timeInvencible = 0.8f;
	private bool invencible = false;

	private int currentHP;
	private AudioSource audio;
	private Animator anim;

	public SpriteRenderer _spriteRenderer;
	public int numBlinksOnInvencible = 5;
	int currentBlink = 0;

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
				anim.SetTrigger("Muerto");
			}

			StartCoroutine(TimeInvencible());
		}
	}

	void SetAlpha(float alpha){
		Color tmp = _spriteRenderer.color;
		tmp.a = alpha;
		 _spriteRenderer.color = tmp;
	}

	void ToogleAlpha(){
		Color tmp = _spriteRenderer.color;
		Debug.Log(_spriteRenderer.color.a);
		if(_spriteRenderer.color.a == 1f)
			tmp.a = 0.4f;
		else
			tmp.a = 1f;

		 _spriteRenderer.color = tmp;
	}

	IEnumerator TimeInvencible()
	{
		while( currentBlink < numBlinksOnInvencible){
			currentBlink ++;
			ToogleAlpha();
			yield return new WaitForSeconds(_timeInvencible);
		}

		currentBlink = 0;

		SetAlpha(1);

		invencible = false;
	}


}
