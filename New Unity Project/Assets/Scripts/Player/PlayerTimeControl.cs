using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode time_key;


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

        }

    }
}
