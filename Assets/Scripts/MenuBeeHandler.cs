using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBeeHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject smallBee;
     private Vector3 spawnPos;
    void Start()
    {
        InvokeRepeating("SpawnBee", 0, 0.4f);
        spawnPos = new Vector3(10.8f, -0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnBee()
    {
        spawnPos = new Vector3(10.8f, Random.Range(5.2f, -5.5f), 0.0f);
        Instantiate(smallBee, spawnPos, Quaternion.identity);
    }
    



}
