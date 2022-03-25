using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabSmall;
    [SerializeField] private GameObject enemyPrefabBig;
    [SerializeField] private int smallSeconds = 10;
    [SerializeField] private int bigSeconds = 15;
    private void Start()
    {
        InvokeRepeating("SpawnSmall", 0, smallSeconds);
        InvokeRepeating("SpawnBig", 8, bigSeconds);
    }


    private void Update()
    {
       
    }

    private void SpawnSmall()
    {
        GameObject enemyInstance = Instantiate(enemyPrefabSmall, new Vector3(11.07f, 2.72f, 0), Quaternion.identity);
    
    }

    private void SpawnBig()
    {
        GameObject enemyInstance = Instantiate(enemyPrefabBig, new Vector3(11.07f, 2.72f, 0), Quaternion.identity);
    }

}
