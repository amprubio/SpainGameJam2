﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    [Header("Delay")]
    public float time;
    public Transform target;
    public Vector2 vel;

    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref vel.x, time);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref vel.y, time);

        transform.position = new Vector3(Mathf.Clamp(posX, xMin, xMax), Mathf.Clamp(posY, yMin, yMax), transform.position.z);
    }
}