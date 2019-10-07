using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject cube;
    public GameObject spawnr;

    public float spawnTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnCube", 0f, 0.5f);
    }

    void SpawnCube() {
        float rand = Mathf.Floor(Random.Range(5f, 10f));
        rand = rand / 10;
        cube.transform.localScale = new Vector3(rand, rand, rand);

        Instantiate(cube, new Vector3(Random.Range(-2,2), spawnr.transform.position.y, 0), Quaternion.identity);
    }

    public void Explode()
    {
        InvokeRepeating("SpawnCube", 0f, 0.01f);
    }
}
