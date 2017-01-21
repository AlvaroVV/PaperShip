using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProbSpawner : MonoBehaviour {

	Dictionary<int, int> _numSpawnedObjecst = new Dictionary<int, int>();

	public float _spawnInterval = 1f;

	// Use this for initialization
	void Start () {
		_numSpawnedObjecst.Add(1, 90);
		_numSpawnedObjecst.Add(2, 8);
		_numSpawnedObjecst.Add(3, 2);

		_numSpawnedObjecst = SortDictionaryByValue(_numSpawnedObjecst);
		_numSpawnedObjecst = ProccessDictionary(_numSpawnedObjecst);
		for(int i = 0; i < _numSpawnedObjecst.Count; i++){
			Debug.Log("k " + _numSpawnedObjecst.ElementAt(i).Key + " v " + _numSpawnedObjecst.ElementAt(i).Value);
		}
		// Debug.Log(_numSpawnedObjecst.First().Value);
		StartCoroutine(SpawnObjectsRoutine());
	}

	Dictionary<int, int> SortDictionaryByValue(Dictionary<int,int> dictionary){
		// return dictionary.Sort((x,y) => x.value.CompareTo(y.value));
		return dictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
	}

	Dictionary<int, int> ProccessDictionary(Dictionary<int, int> dictionary){
		Dictionary<int, int> proccessedDictionary = new Dictionary<int, int>();

		int acumulator = dictionary.ElementAt(0).Value;
		proccessedDictionary.Add(dictionary.ElementAt(0).Key, acumulator);
		for(int i=1; i< _numSpawnedObjecst.Count; i++){
			acumulator += dictionary.ElementAt(i).Value;
			proccessedDictionary.Add(dictionary.ElementAt(i).Key, acumulator);
		}

		return proccessedDictionary;
	}

	IEnumerator SpawnObjectsRoutine(){
		int selectedIndex = -1;
		while(true){
			yield return new WaitForSeconds(_spawnInterval);
			SpawnAt(SelectIndexPosition());
		}
	}



	int SelectIndexPosition(){
		int index = -1;

		int rand = Random.Range(1, 100);
		for(int i = 0; i < _numSpawnedObjecst.Keys.Count; i++){
			if(_numSpawnedObjecst.ElementAt(i).Value > rand){
				index = _numSpawnedObjecst.ElementAt(i).Key;
				break;
			}
		}

		return index;
	}

	void SpawnAt(int indexPosition){
		Debug.Log("Spawn at index " + indexPosition);
	}
}
