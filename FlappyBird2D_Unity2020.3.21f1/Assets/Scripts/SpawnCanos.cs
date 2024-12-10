using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanos : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;

    public float minHeight = -1f;

    public float maxHeight = 1f;
    
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject Canos = Instantiate(prefab, transform.position, Quaternion.identity);
        Canos.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); 
    }
}

