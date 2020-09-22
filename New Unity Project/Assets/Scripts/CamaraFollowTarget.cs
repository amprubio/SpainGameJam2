using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollowTarget : MonoBehaviour
{
    [Header("Limitación de la camara")]
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    [Header("Variables para que se agite la camara")]
    public float time;
    public float shakePower;
    public float shakeDuration;


    private float shakeTimer;
    private float shakeForce;
    public Transform player;
    private Vector2 velocidad;


    void LateUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocidad.x, time);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocidad.y, time);

        transform.position = new Vector3(Mathf.Clamp(posX, xMin, xMax), Mathf.Clamp(posY, yMin, yMax), transform.position.z);


    }

    private void Update()
    {
        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeForce;

            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);


            shakeTimer = shakeTimer - Time.deltaTime;
        }


    }
    public void ShakeCamera(float shakePower, float shakeDuration)
    {
        shakeForce = shakePower;
        shakeTimer = shakeDuration;
    }


}