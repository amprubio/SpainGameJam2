using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Use to manipulate the RigidBody of a GameObject
    public GameObject bullet_object;
    public KeyCode shooting_key;
    public float shootSpeed;
    public float shootDelay;
    public Camera camara_de_jugador;

    //bullet duplicate
    GameObject copy;

    //needed vars
    Transform m_Transform;


    //positions
    Vector2 pos;
    Vector2 mousePos;
    Vector2 shootDirection;
    float shootTimer;

    static Plane XYPlane = new Plane(Vector3.forward, Vector3.zero);

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Transform component attached to the GameObject
        m_Transform = GetComponent<Transform>();

        //initial vector
        shootDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        pos = m_Transform.position;
        mousePos = GetMousePositionOnXYPlane();


        Debug.DrawLine(pos, mousePos, Color.green);

        shootDirection = mousePos - pos;
        shootDirection.Normalize();

        if (Input.GetKeyDown(shooting_key))
        {
            if ( GameManager.instance.IsPlayerIdle() &&
                 GameManager.instance.IsGameStateStart() ) {
                GameManager.instance.PlayerShooting();
                copy = Instantiate(bullet_object, pos, Quaternion.identity);
                copy.SetActive(true);
                BulletMovement b = copy.GetComponent<BulletMovement>();
                b.setDir(shootDirection);
                shootTimer = 0;
            }
        }

        if ( GameManager.instance.IsPlayerShooting() )
        {
            shootTimer += Time.deltaTime;
        }

        if (shootTimer >= shootDelay)
        {
            shootTimer = 0;
            GameManager.instance.PlayerIdle();
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
