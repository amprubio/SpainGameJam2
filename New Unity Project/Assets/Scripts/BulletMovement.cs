using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [Header("Velocidad")]
    public float speed;

    Vector2 dir;
    private void FixedUpdate()
    {
        transform.Translate(dir.x*speed,dir.y*speed,0);
    }

    public void setDir(Vector2 v) { dir = v; }
}
