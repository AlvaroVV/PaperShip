using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
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

	IEnumerator routine;

	Vector3 initialScale;
	bool initialRestart = true;

	void Start()
	{
		anim = GetComponentInChildren<Animator>();
		audio = GetComponent<AudioSource>();
		currentHP = _health;
		initialScale = transform.localScale;

	}

	public void Restart(){
		currentHP = _health;
		if(initialRestart){
			initialRestart = false;
		}
		else{
			anim.SetTrigger("Restart");
		}
		transform.localScale = initialScale;
		if(routine != null)
			StopCoroutine(routine);
		SetAlpha(1);
	}

	public void Hit(int damage){
		if(!invencible)
		{
			invencible = true;
			currentHP -= damage;
			audio.Play();
			if (currentHP <= 0)
			{
				anim.SetTrigger("Muerto");
				GameManager.Instance.GameOver(true);
			}
			else{
				anim.SetTrigger("Vida" + currentHP);
			}
			routine = TimeInvencible();
			StartCoroutine(routine);
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
