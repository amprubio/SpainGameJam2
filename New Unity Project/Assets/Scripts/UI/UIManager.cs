using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("Panel de pausa")]
    public GameObject pausePanel;
    
    [Header("Panel de pausa")]
    public GameObject startPanel;
    
    [Header("vida")]
    public GameObject gameUI;


    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivatePausePanel()
    {
        pausePanel.SetActive(true);
    }
    public void DesactivatePausePanel()
    {
        pausePanel.SetActive(false);
    }
    public void ActivateStartPanel()
    {
        startPanel.SetActive(true);
    }
    public void DesactivateStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ActivateGameUI()
    {
        gameUI.SetActive(true);
    }
    public void DesactivateGameUI()
    {
        gameUI.SetActive(false);
    }
}
