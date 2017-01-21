using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPool : MonoBehaviour {

    public float spawnWait = 0.5f;
    public float waveWait = 2.0f;
    public int waveLoop = 5;
    //características SpawnerLoop
    private Vector3 min;
    private Vector3 max;

    //Pool de Spawns
    public GameObject spwan;
    public int amountPool = 3;
    private List<GameObject> poolSpawns = new List<GameObject>();


	// Use this for initialization
	void Start () {
        float camWidth = ResolutionManager.Instance.GetCameraWidth();
        min = new Vector3(ResolutionManager.Instance.GetCameraPosition().x - (camWidth/2) + (camWidth *0.3f), transform.position.y,0);
        max = new Vector3(ResolutionManager.Instance.GetCameraPosition().x - (camWidth / 2) + (camWidth * 0.7f), transform.position.y, 0);
       
        CreatePool();
        //StartCoroutine(SpawnObjects());
        StartCoroutine(SpawnRandomObjects());
    }
	
	// Update is called once per frame
	void Update () {

        //transform.position = Vector3.Lerp(min, max, Mathf.PingPong(Time.time * speed, 1.0f));

    }

    /*
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            GetSpawnToPool().SetActive(true);

            yield return new WaitForSeconds(Random.Range(MinRandomTime, MaxRandomTime));
        }
    }
    */

    IEnumerator SpawnRandomObjects()
    {
        while (true)
        {
            int maxLoop = Random.Range(1, waveLoop);
            float finalWaveWait = Random.Range(0.2f, waveWait);
            Debug.Log("WaveLoop -> " + maxLoop);
            Debug.Log("WaveWait ->" + finalWaveWait);
            for (int i = 0; i < maxLoop; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(min.x, max.x), transform.position.y, 0);
                GameObject spawn = GetSpawnToPool();
                spawn.transform.position = randomPosition;
                spawn.SetActive(true);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(finalWaveWait);
        }
    }

    private void CreatePool()
    {
        for(int i = 0; i<amountPool; i++)
        {
            CreateSpawn("Spawn_" + i);
        }
    }

    private GameObject GetSpawnToPool()
    {
        foreach (GameObject go in poolSpawns)
            if (!go.activeSelf)
                return go;
        return CreateSpawn("Spawn_" + ++amountPool);
       
    }

    private GameObject CreateSpawn(string name)
    {
        GameObject gameObject = Instantiate(spwan, transform.position, Quaternion.identity);
        
        gameObject.name = name;
        gameObject.SetActive(false);
        poolSpawns.Add(gameObject);
        return gameObject;
    }
}
