using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float time_;
    void Start()
    {
        Destroy(this.gameObject, time_* Time.deltaTime);
    }
}
