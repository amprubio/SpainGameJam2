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
        if (GameManager.instance.IsGameStateStart() && GameManager.instance.IsMoving())
        {

            transform.Translate(dir.x * speed, dir.y * speed, 0);
        }
    }

    public void setDir(Vector2 v) { dir = v; }

    void OnCollisionStay2D(Collision2D col)
    {
        if (!(col.gameObject.CompareTag("Player")))
        {
           //quitar vida a col si tiene
           
           Destroy(this.gameObject);
        }
    }
}
