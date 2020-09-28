using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFacing : MonoBehaviour
{
    public GameObject target;

    BulletMovement bMov;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        bMov = target.GetComponentInParent<BulletMovement>();
        dir = bMov.getDir();
        GetComponent<Transform>().rotation = Quaternion.FromToRotation(Vector2.up, dir);
    }
}
