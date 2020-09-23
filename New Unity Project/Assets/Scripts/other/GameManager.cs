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

    public enum PlayerStateMachine : int
    {
        IDLE,       //not doing anything
        MOVE,       //moving
        ATTACKING,      //attacking
        SHOOTING,      //attacking
        DASHING,      //doing a dash
    };

    private StateMachine GameState;
    private EntityMovState EntMoveState;
    private PlayerStateMachine PlayerState;

    public StateMachine GetStateMachine() { return GameState; }
    public bool IsGameStateStart() { return GameState == StateMachine.GAMESTART; }
    public bool IsGameStatePause() { return GameState == StateMachine.PAUSE;}
    public bool IsGameStateOver() { return GameState == StateMachine.GAMEOVER;}
    public bool IsGameStateStartMenu() { return GameState == StateMachine.GAMEOVER;}

    public EntityMovState GetEntityMov() { return EntMoveState; }
    public bool IsMoving() { return EntMoveState == EntityMovState.MOVE; }
    public bool IsFreeze() { return EntMoveState == EntityMovState.TIMEFREEZE; }
    public bool IsStop() { return EntMoveState == EntityMovState.STOP; }

    public PlayerStateMachine GetPlayerState() { return PlayerState; }
    public bool IsPlayerIdle() { return PlayerState == PlayerStateMachine.IDLE; }
    public bool IsPlayerMoving() { return PlayerState == PlayerStateMachine.MOVE;}
    public bool IsPlayerAttacking() { return PlayerState == PlayerStateMachine.ATTACKING;}
    public bool IsPlayerShooting() { return PlayerState == PlayerStateMachine.SHOOTING;}
    public bool IsPlayerDashing() { return PlayerState == PlayerStateMachine.DASHING;}

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
        PlayerState = new PlayerStateMachine();
        PlayerIdle();
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
        Debug.Log ("Entity movement: TIMEFREEZE");
    }

    public void Stop() {
        EntMoveState = EntityMovState.STOP;
        Debug.Log ("Entity movement: STOP");
    }
    //////// ENTITY MOV STATE ////////
    //////////////////////////////////

    //////////////////////////////////
    //////// ENTITY MOV STATE ////////
    public void PlayerIdle() {
        PlayerState = PlayerStateMachine.IDLE;
        Debug.Log ("Player state: IDLE");
    }

    public void PlayerMove() {
        PlayerState = PlayerStateMachine.MOVE;
        Debug.Log ("Player state: MOVE");
    }

    public void PlayerAttacking() {
        PlayerState = PlayerStateMachine.ATTACKING;
        Debug.Log ("Player state: ATTACKING");
    }

    public void PlayerShooting() {
        PlayerState = PlayerStateMachine.SHOOTING;
        Debug.Log ("Player state: SHOOTING");
    }

    public void PlayerDashing() {
        PlayerState = PlayerStateMachine.DASHING;
        Debug.Log ("Player state: DASHING");
    }

    //////// ENTITY MOV STATE ////////
    //////////////////////////////////
}
