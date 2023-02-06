using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnrate = 1f;
    public float minheight = -1f;
    public float maxheight = 1f;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnrate,spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab,transform.position,quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minheight, maxheight);
    }

}

