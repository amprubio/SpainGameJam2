using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnGameObjectOnce : MonoBehaviour
{

    public GameObject boss;
    private bool spawned;
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsGameStateStart()&& !spawned)
        {
            Instantiate(boss, transform.position, Quaternion.identity);
            spawned = true;
        }
        else if (GameManager.instance.IsGameStateStartMenu())
        {
            spawned = false;
        }

    }
}
