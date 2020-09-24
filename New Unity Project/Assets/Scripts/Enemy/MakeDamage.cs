using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vida v = col.gameObject.GetComponent<Vida>();
            v.MakeDamage(damage);
        }
    }
}
