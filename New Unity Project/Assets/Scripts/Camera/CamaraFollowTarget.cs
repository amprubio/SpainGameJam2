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
    public float desplazamiento_y;
   
    public Transform player;
    private Vector2 velocidad;

    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    void LateUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocidad.x, time);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y+desplazamiento_y, ref velocidad.y, time);

        transform.position = new Vector3(Mathf.Clamp(posX, xMin, xMax), Mathf.Clamp(posY, yMin, yMax), transform.position.z);


    }
   public void Enable(float t)
    {
        shakeDuration = t;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition += Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
        }
    }




}
