using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawning : MonoBehaviour
{
    private GameObject enemyCube;
    private GameObject newSpawn;

    // Start is called before the first frame update
    void Start()
    {
        enemyCube = GameObject.Find("Enemy");
        for(var i=0; i<28; i++)
        {
            Vector3 pos = new Vector3(Random.Range(300.0f, 750.0f), 0, Random.Range(330.0f, 710.0f));
            pos.y = Terrain.activeTerrain.SampleHeight(pos) + 2.0f;
            newSpawn = Instantiate(enemyCube, pos, new Quaternion(0.0f, 90.0f, 90.0f, 0.0f));
        }
    }
}
