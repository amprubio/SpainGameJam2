using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [Header("")]
    public float speedx, speedy;
    float x_, y_;
    private Rigidbody2D rb;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 v = Vector2.zero;
        v.x = x_ * speedx;
        v.y= y_ * speedy;

        rb.AddForce(v * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void setSpeed(float x, float y)
    {
        x_ = x;
        y_ = y;
    }
}
