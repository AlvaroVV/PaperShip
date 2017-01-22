using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public Text text;
	public delegate void HealthEvent(int health);
	public HealthEvent OnHealthChanged;

	public int _health;
    public int _timeInvencible = 2;
    private bool invencible = false;

    private int currentHP;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        currentHP = _health;
        text.text = currentHP + "/" + _health;
    }

	public void Hit(int damage){
        if(!invencible)
        {
            invencible = true;
		    currentHP -= damage;
            text.text = currentHP + "/" + _health;
            audio.Play();
            if (currentHP <= 0)
            {
                Debug.Log("MUERTO");
            }

            StartCoroutine(TimeInvencible());
		}
	}

    IEnumerator TimeInvencible()
    {
        
        GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
        yield return new WaitForSeconds(_timeInvencible);
        GetComponent<MeshRenderer>().sharedMaterial.color = Color.white;
        invencible = false;
    }


}
