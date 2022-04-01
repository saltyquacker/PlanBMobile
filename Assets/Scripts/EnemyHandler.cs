using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabSmall;
    [SerializeField] private GameObject enemyPrefabBig;
    [SerializeField] private int smallSeconds = 10;
    [SerializeField] private int bigSeconds = 30;

    private GameObject scoreHandler;
    private ScoreHandler scoreScript;


    [SerializeField]private int countBees;
    private void Start()
    {
        scoreHandler= GameObject.Find("ScoreHandler");
        scoreScript = scoreHandler.GetComponent<ScoreHandler>();

        countBees = 0;
        InvokeRepeating("SpawnSmall", 0, smallSeconds);
        InvokeRepeating("SpawnBig", 15, bigSeconds);
    }


    private void Update()
    {
        Debug.Log(countBees + " bees made.");
        //Dont spawn any more bees if we reach max amount of bees
        if(countBees>= scoreScript.beeMax)
        {
            Debug.Log("CANCEL INVOKE!");
            CancelInvoke();
           
        }
    }

    private void SpawnSmall()
    {
        GameObject enemyInstance = Instantiate(enemyPrefabSmall, new Vector3(11.07f, 2.72f, 0), Quaternion.identity);
        countBees += 1;
    }

    private void SpawnBig()
    {
        GameObject enemyInstance = Instantiate(enemyPrefabBig, new Vector3(11.07f, 2.72f, 0), Quaternion.identity);
        countBees += 1;
    }

}
