using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnBoss : MonoBehaviour
{
    [Header("Time")]
    public float time;

    public GameObject enemy;

    [Range(0,100)]
    public int chance;


    System.Random rnd = new System.Random();

    void Update()
    {

        Invoke("CreateEnemy", time);
    }

    private void CreateEnemy()
    {
        int i = rnd.Next(0, 100);
        if (i < chance)
        {
            Instantiate(enemy, this.transform.position, Quaternion.identity);
        }
    }
}
