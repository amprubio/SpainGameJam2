using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StateMachine(GameOver,GameStart,Pause,StartMenu);
// EntityMovState(Move,TimeFreeze,Stop);

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    private StateMachine GameState;
    private EntityMovState EntMoveState;
   
    public StateMachine GetStateMachine() { return GameState; }
    public bool IsGameStateStart() { return GameState == StateMachine.GAMESTART; }
    public bool IsGameStatePause() { return GameState == StateMachine.PAUSE;}
    public bool IsGameStateOver() { return GameState == StateMachine.GAMEOVER;}
    

    public EntityMovState GetEntityMov() { return EntMoveState; }

    public bool IsMoving() { return EntMoveState == EntityMovState.MOVE; }
    public bool IsFreeze() { return EntMoveState == EntityMovState.TIMEFREEZE; }
    public bool IsStop() { return EntMoveState == EntityMovState.STOP; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        GameState = new StateMachine();
        GameStart(); 
        EntMoveState = new EntityMovState();
        Move();
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
