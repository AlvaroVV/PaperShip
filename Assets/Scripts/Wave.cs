using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	//Número de escalados que tiene la onda
	public int _numWaves = 10;

	//Radio actual de la onda
	float _waveRadius = .1f;

	//Incremento de escalado de la onda
	public float _waveScaleIncrement = 1;

	//Intervalo de tiempo entre escalados de la onda
	public float _timeBetweenScale = .5f;

	//Factor de fuerza de la onda
	public float _waveForceScale = 50f;

	//Factor de fuerz de la onda "según la distancia"
	public float _strengthForceScale = 200f;

	public bool _rotationActive = false;

	//Lista de GameObjects impulsados por una onda (para no volver a impulsarlos)
	List<GameObject> _hitGameObjects = new List<GameObject>();


	// Use this for initialization
	void Start () {
	}

	public void StartWave(){
		StartCoroutine(ExpandWave());
	}

	//Timeline del radio de la onda
		//escala el radio
		//comprueba si impacta con un objeto al que puede afectar la onda
			//empuja el objeto
	IEnumerator ExpandWave(){

		int nWaves = _numWaves;
		while(nWaves > 0){

			//Set new scale for wave
			_waveRadius += _waveScaleIncrement;
			Vector3 newScale = new Vector3(_waveRadius, 1, _waveRadius);
			gameObject.transform.localScale = newScale;

			//Comprueba los objetos que golpea la onda
			Collider2D[] waveColls = Physics2D.OverlapCircleAll(
				transform.position,
				_waveRadius,
				1 << LayerMask.NameToLayer("Wavable")
			);

			//Mueve los objetos golpeados
			foreach(Collider2D coll in waveColls){
				if(!_hitGameObjects.Contains(coll.gameObject)){
					Vector2 waveForceDirection = (coll.gameObject.transform.position - transform.position).normalized;

					if(!_rotationActive){


						MoveGameObjectByWave(
							coll.gameObject,
							waveForceDirection,
							_waveForceScale,
							(float)nWaves /(float)_numWaves,
							_strengthForceScale
						);
					}
					else{
						RaycastHit2D hit = Physics2D.Raycast(transform.position, waveForceDirection);

						if (hit.collider){
							MoveGameObjectByWave(
								coll.gameObject,
								hit.point,
								waveForceDirection,
								_waveForceScale,
								(float)nWaves /(float)_numWaves,
								_strengthForceScale
							);
						}

					}
					//Guarda el objeto golpeado para no volver a golpearlo

					_hitGameObjects.Add(coll.gameObject);
				}
			}

			nWaves--;
			yield return new WaitForSeconds(_timeBetweenScale);
		}
		Destroy(gameObject, 1f);
		yield return null;
	}

	//Impulsa el objeto
	//forceDirection: Dirección de la fuerza que aplica la onda al objeto
	//forceMultiplier: Magnitud base de fuerza aplicada en esa dirección
	//strength: Proporción de fuerza aplicada según la distancia (0,1]
	//strengthMultiplier: Magnitud de fuerza aplicada a la proporción de fuerza
	void MoveGameObjectByWave(GameObject go, Vector2 forceDirection, float forceMultiplier, float strength, float strengthMultiplier){
		Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
		if(!rb) return;

		Vector2 totalForce = forceDirection * forceMultiplier +
					forceDirection * strength *strengthMultiplier;

		rb.AddForce(totalForce);
	}

	void MoveGameObjectByWave(GameObject go, Vector2 hitPoint, Vector2 forceDirection, float forceMultiplier, float strength, float strengthMultiplier){
		Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
		if(!rb) return;

		Vector2 totalForce = forceDirection * forceMultiplier +
					forceDirection * strength *strengthMultiplier;

		rb.AddForceAtPosition(totalForce, go.transform.InverseTransformPoint(hitPoint));
	}
}
