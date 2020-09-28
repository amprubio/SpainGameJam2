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
            if (!GameManager.instance.IsPlayerAttacking())
            {
                Vida v = col.gameObject.GetComponent<Vida>();
                v.MakeDamage(damage);
                GameObject.Find("Main Camera").GetComponent<CamaraFollowTarget>().Enable(2f);
            }
        }
    }
}
