using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateLegs : MonoBehaviour
{
    Animator anim;
    Transform tf;

    public Camera camara_de_jugador;
    public GameObject baseObject;
    public GameObject animObject;
    Vector2 moveDir;
    Vector2 displacement;
    Vector2 prePos;
    Vector2 postPos;

    //positions
    Vector2 mousePos;
    Vector2 lookDirection;
    Vector2 relativeVelocity;
    Transform m_Transform;

    static Plane XYPlane = new Plane(Vector3.forward, Vector3.zero);

    float angleDiff;
    float dirX, dirY;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = animObject.GetComponent<Animator>();
        tf = GetComponent<Transform>();
        anim.SetInteger("moving", 1); // 0 forwards, 1 idle, 2 backwards
        dirX =dirY= 0;
    }

    // Update is called once per frame
    void Update()
    {
        prePos = tf.position;

        displacement = postPos - prePos;
        displacement.Normalize();

        mousePos = GetMousePositionOnXYPlane();
        lookDirection = mousePos - prePos;
        lookDirection.Normalize();

        //Debug.DrawRay(prePos, relativeVelocity, Color.green);
        float angle = Vector2.SignedAngle(lookDirection,Vector2.up);

        relativeVelocity = RotateAngle(displacement,angle);

        angleDiff = Vector2.SignedAngle(relativeVelocity, Vector2.up);
        Debug.Log(Mathf.Abs(angleDiff));


        Debug.DrawRay(prePos, lookDirection, Color.red);
        Debug.DrawRay(prePos, relativeVelocity, Color.green);

        float testAngle = Mathf.Abs(angleDiff);

        Vector2 testVectorMagnitude = postPos - prePos;
        if ( testVectorMagnitude.magnitude > 0.5f ) {
            if ( testAngle < 45 ) {
                anim.SetInteger("movingY", 0); // 0 forwards, 1 idle, 2 backwards
            }

            if ( testAngle > 135 ) {
                anim.SetInteger("movingY", 2); // 0 forwards, 1 idle, 2 backwards
            }
        } else {
            anim.SetInteger("movingY", 1); // 0 forwards, 1 idle, 2 backwards
        }

        if ( testAngle >= 45 && testAngle <= 135 ) {
            anim.SetInteger("movingY", 1); // 0 forwards, 1 idle, 2 backwards
        }
        Debug.Log(anim.GetInteger("movingY"));
    }

    void LateUpdate(){
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        postPos = tf.position + new Vector3(dirX,dirY,0);
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

   Vector2 RotateAngle(Vector2 v,float _angle) {
        _angle = _angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(_angle);
        float sin = Mathf.Sin (_angle);
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
   }
}
