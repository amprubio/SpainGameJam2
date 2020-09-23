using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StateMachine(GameOver,GameStart,Pause,StartMenu);
// EntityMovState(Move,TimeFreeze,Stop);

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public enum StateMachine : int
    {
        GAMEOVER,
        GAMESTART,
        PAUSE,          //Player is viewing in-game menu
        STARTMENU      //Player is viewing game start menu
    };

    public enum EntityMovState : int
    {
        MOVE,       //everyone can move
        TIMEFREEZE,      //only player CAN move, enemies and enviroment DON'T move
        STOP
    };

    public StateMachine GameState;
    public EntityMovState EntMoveState;

    public static GameManager Instance {
        get {
            if(instance==null) {
                instance = new GameManager();
            }

            return instance;
        }
    }

    ///////////////////////////////
    //////// STATE MACHINE ////////
    public void GameOver() {
        GameState = StateMachine.GAMEOVER;
        Debug.Log ("Game state: GAMEOVER");
    }

    public void GameStart() {
        GameState = StateMachine.GAMESTART;
        Debug.Log ("Game state: GAMESTART");
    }

    public void Pause() {
        GameState = StateMachine.PAUSE;
        Debug.Log ("Game state: PAUSE");
    }

    public void StartMenu() {
        GameState = StateMachine.STARTMENU;
        Debug.Log ("Game state: STARTMENU");
    }
    //////// STATE MACHINE ////////
    ///////////////////////////////

    //////////////////////////////////
    //////// ENTITY MOV STATE ////////
    public void Move() {
        EntMoveState = EntityMovState.MOVE;
        Debug.Log ("Entity movement state: MOVE");
    }

    public void TimeFreeze() {
        EntMoveState = EntityMovState.TIMEFREEZE;
        Debug.Log ("Game state: TIMEFREEZE");
    }

    public void Stop() {
        EntMoveState = EntityMovState.STOP;
        Debug.Log ("Game state: STOP");
    }
    //////// ENTITY MOV STATE ////////
    //////////////////////////////////

}
