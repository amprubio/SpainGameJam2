using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode time_key;
    public int maxtime_;

    private int currentTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if (GameManager.instance.IsGameStateStart())
       {
            if (Input.GetKeyDown(time_key))
            {
                if (GameManager.instance.IsMoving())
                {
                    GameManager.instance.TimeFreeze();
                }
                else
                {
                    GameManager.instance.Move();
                }
            }
            if (GameManager.instance.IsFreeze())
            {
                Invoke("LessTime", 1*Time.deltaTime);
            }

        }
        else
        {
            currentTime = maxtime_;
        }
    }
    private void LessTime()
    {
        Debug.Log("Time--");
    }
}
