using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Camera camara_de_jugador;
    [Header("Tiempo que tarda en mirar (segundos)")]
    public float look_delay;

    //positions
    Vector2 pos;
    Vector2 mousePos;
    Vector2 lookDirection;
    Transform m_Transform;

    //rotation
    Quaternion new_rotation;


    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();

        //initial vector
        lookDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        pos = m_Transform.position;
        mousePos = camara_de_jugador.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector2(mousePos.x, mousePos.y);

        lookDirection = mousePos - pos;
        if (lookDirection.magnitude>1) {

            lookDirection.Normalize();
            new_rotation = Quaternion.FromToRotation(Vector2.up, lookDirection);
            m_Transform.rotation = Quaternion.Slerp(transform.rotation, new_rotation,  Time.deltaTime / look_delay);
        }

    }
}
