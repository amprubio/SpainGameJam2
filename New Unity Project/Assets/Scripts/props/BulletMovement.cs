using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [Header("Velocidad")]
    public float speed;
    public int damage;
    Vector2 dir;

    private void FixedUpdate()
    {
        if (GameManager.instance.IsGameStateStart() && GameManager.instance.IsMoving())
        {
            transform.Translate(dir.x * speed, dir.y * speed, 0);
        }
    }

    public void setDir(Vector2 v) { dir = v; }
    public Vector2 getDir() { return dir; }

    void OnCollisionStay2D(Collision2D col)
    {
        if (!(col.gameObject.CompareTag("Player")))
        {
            Vida v = col.gameObject.GetComponent<Vida>();
            if (v != null)
            {
                v.MakeDamage(damage);
                Debug.Log("BOOM");
                Destroy(this.gameObject);
            }
        }
    }
}
