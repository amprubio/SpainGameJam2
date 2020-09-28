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

    static Plane XYPlane = new Plane(Vector3.forward, Vector3.zero);

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
        mousePos = GetMousePositionOnXYPlane();

        lookDirection = mousePos - pos;
        if (lookDirection.magnitude>1 &&
            !GameManager.instance.IsPlayerAttacking() &&
            GameManager.instance.IsGameStateStart() ) {

            lookDirection.Normalize();
            new_rotation = Quaternion.FromToRotation(Vector2.up, lookDirection);
            m_Transform.rotation = Quaternion.Slerp(transform.rotation, new_rotation,  Time.deltaTime / look_delay);
            //Debug.DrawLine(m_Transform.position,new Vector3(mousePos.x,mousePos.y,0),Color.green);
        }

    }

    //get mouse position on plane XY
    Vector2 GetMousePositionOnXYPlane() {
       float distance;
       Ray ray = camara_de_jugador.ScreenPointToRay(Input.mousePosition);
       if(XYPlane.Raycast (ray, out distance)) {
           Vector3 hitPoint = ray.GetPoint(distance);
           hitPoint.z = 0;

           return new Vector2(hitPoint.x, hitPoint.y);
       }
       return new Vector2(0, 0);
   }
}
