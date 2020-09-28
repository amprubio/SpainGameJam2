using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVida : MonoBehaviour
{

    [Header("Corazones de la UI")]
    public Image[] images;

    public GameObject jugador;
    private Vida vida_jugador;
   
    void Start()
    {
        vida_jugador = jugador.GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

        int v = vida_jugador.GetCurrentHealth();
        for (int i = 0; i <v ; i++)
        {
            images[i].gameObject.SetActive(true);
        }
        Debug.Log("Vida:" +v);
    }
}
