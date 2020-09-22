using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedx, speedy;
    private float dirX, dirY;
    private Transform tr_;
    // Start is called before the first frame update
    void Start()
    {
        dirX =dirY= 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        transform.Translate(dirX*speedx*Time.deltaTime, dirY*speedy * Time.deltaTime, 0);
    }
}
