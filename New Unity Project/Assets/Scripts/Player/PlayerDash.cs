using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    //we take first rotation to be upwards
    [Header("Variables iniciadas")]
    public float dashSpeed;
    public float dashDuration;
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
    Vector2 dashVector;

    //vars
    bool dashing;
    float dashTimer;


    // Start is called before the first frame update
    void Start()
    {
       //Fetch the RigidBody component attached to the GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();

        //Fetch the Transform component attached to the GameObject
        m_Transform = GetComponent<Transform>();

        //initial vector
        forwardVector = dashVector = Vector2.up;
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsGameStateStart())
        {
            prePos = m_Transform.position;
            if (prePos - postPos != Vector2.zero)
            {
                forwardVector = prePos - postPos;
                forwardVector.Normalize();
            }

            if (Input.GetKeyDown(dashKey))
            {
                dashing = true;
                dashVector = forwardVector;
            }

            if (dashing) {
                dashTimer += Time.deltaTime;
                m_Rigidbody.velocity = dashVector * dashSpeed;
            }

            if (dashTimer >= dashDuration)
            {
                dashTimer = 0;
                dashing = false;
                m_Rigidbody.velocity = Vector2.zero;
            }


            postPos = m_Transform.position;
        }
    }
}
