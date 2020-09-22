using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCollide : MonoBehaviour
{
    public GameObject objetivo;
    public LayerMask Capa_de_collision;

    RaycastHit2D hit;
    Collider2D m_Collider;
    Collider2D targetCollider;
    Transform m_Transform;

    //positions
    Vector2 prePos;
    Vector2 postPos;
    Vector2 moveVector;
    float test;

    void Start()
    {
       //Fetch the RigidBody component attached to the GameObject
        m_Collider = GetComponent<Collider2D>();

        //Fetch the Transform component attached to the GameObject
        m_Transform = GetComponent<Transform>();

        //objective collider
        targetCollider = objetivo.GetComponent<Collider2D>();

        //initial vector
        moveVector = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prePos = m_Transform.position;

        moveVector = postPos-prePos;

        Debug.DrawRay(prePos, moveVector, Color.yellow);

        RaycastHit2D[] hit = Physics2D.RaycastAll(prePos, postPos, moveVector.magnitude, Capa_de_collision);


            foreach (RaycastHit2D element in hit)
            {
                Debug.Log(element.collider);
            }


        if (test < moveVector.magnitude) {
            test = moveVector.magnitude;
            Debug.Log(test);
        }



        /*if (GameObject.Find(hit.collider.gameObject.objetivo) ) {
            Debug.Log("hit");
        }*/

        postPos = m_Transform.position;
    }
}
