using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirl : MonoBehaviour {

	public float timeToEat = 0.1f;
	float timeInSwirl = 0;

	bool swirlActive = true;

	float eatScale = 0.05f;
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Boat"){
			timeInSwirl += Time.deltaTime;
			Debug.Log("timeInSwirl " + timeInSwirl);

			if(swirlActive && timeInSwirl > timeToEat){
				Debug.Log("eat");
				swirlActive = false;
				StartCoroutine(Eat(other.gameObject));
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		timeInSwirl = 0;
	}

	IEnumerator Eat(GameObject go){

		while(go.transform.localScale.x > 0.2f){
			go.transform.localScale -= new Vector3(eatScale, eatScale, 1);
			yield return null;
		}

		go.SetActive(false);
	}

}
