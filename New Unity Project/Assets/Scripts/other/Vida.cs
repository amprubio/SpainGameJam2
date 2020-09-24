using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int max_health;
    private int curr_health;
    void Start()
    {
        ResetLife();
    }
    public int GetCurrentHealth()
    {
        return curr_health;
    }
    public void ResetLife()
    {
        curr_health = max_health;
    }
     public void MakeDamage(int damage)
    {
        curr_health-=damage;

        if (curr_health < 0)
        {
            Destroy(this.gameObject);
        }

    }
}
