using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    //we take first rotation to be upwards
    [Header("Variables iniciadas")]
    public float rotacion_inicial;
    public float dashDistance;
    public KeyCode dashKey = KeyCode.Space;

    //Use to apply force to RigidBody
    Vector2 m_NewForce;

    //Use to manipulate the RigidBody of a GameObject
    Rigidbody2D m_Rigidbody;

    //Use to manipulate the Transform of a GameObject
    Transform m_Transform;

    //positions
    Vector2 prePos;
    Vector2 postPos;
    Vector2 forwardVector;

    //vars
    float rotationAngle;
    float xImpulse;
    float yImpulse;


    // Start is called before the first frame update
    void Start()
    {
       //Fetch the RigidBody component attached to the GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();

        //Fetch the Transform component attached to the GameObject
        m_Transform = GetComponent<Transform>();

        //initial vector
        forwardVector = Vector2.up;

        m_Rigidbody.drag = dashDistance*10;
    }

    // Update is called once per frame
    void Update()
    {
        prePos = m_Transform.position;
        if (prePos-postPos != Vector2.zero) {
            forwardVector = prePos-postPos;
            forwardVector.Normalize();
        }

        if (Input.GetKeyDown(dashKey))
        {
            //Use Impulse mode as a force on the RigidBody
            m_Rigidbody.AddForce(forwardVector*100*dashDistance, ForceMode2D.Impulse);
        }

        postPos = m_Transform.position;
    }
}
