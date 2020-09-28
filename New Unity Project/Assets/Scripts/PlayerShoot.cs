using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Use to manipulate the RigidBody of a GameObject
    public GameObject bullet_object;
    public KeyCode shooting_key;

    //bullet duplicate
    GameObject copy;

    //needed vars
    Transform m_Transform;
    Rigidbody2D target_Rigidbody;

    //positions
    Vector2 pos;
    Vector2 mousePos;
    Vector2 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the RigidBody component attached to the GameObject
        target_Rigidbody = bullet_object.GetComponent<Rigidbody2D>();

        //Fetch the Transform component attached to the GameObject
        m_Transform = GetComponent<Transform>();

        //initial vector
        shootDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        pos = m_Transform.position;
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        shootDirection = pos-mousePos;
        shootDirection.Normalize();

        if (Input.GetKeyDown(shooting_key))
        {
            copy = Instantiate(bullet_object, pos, Quaternion.identity);
            copy.SetActive(true);

        }
    }
}
