using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScythe : MonoBehaviour
{
    [Header("Variables manipulables")]
    public float attackSpeed;
    public KeyCode attackKey;

    [Header("Necesario configurar")]
    public GameObject scythePivot;
    public GameObject scytheTrail;

    Animator anim;
    TrailRenderer trail;
    Animation slash;
    bool can_attack;
    public GameObject col_;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

        anim = scythePivot.GetComponent<Animator>();
        trail = scytheTrail.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("stop")) {
            can_attack = true;
            trail.Clear();

            if (GameManager.instance.IsPlayerAttacking()) {
                GameManager.instance.PlayerIdle();
            }

        }

        if (can_attack) {
            if ( Input.GetKeyDown(attackKey) ) {
                if ( !GameManager.instance.IsPlayerDashing() &&
                     !GameManager.instance.IsPlayerShooting() ) {
                    anim.Play("attack", 0, 1/attackSpeed);
                    can_attack = false;
                    GameManager.instance.PlayerAttacking();
                    col_.SetActive(true);
                }
            }
            else
            {
                col_.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       
    }

}
