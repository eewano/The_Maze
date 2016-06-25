using UnityEngine;
using System.Collections;

public class ManagerState : MonoBehaviour {

    public enum GameState {
        READY,
        READYGO,
        PLAYING,
        GIVEUP,
        MAP,
        TIMEUP,
        FAILURE,
        GOAL,
        CLEAR,
        GAMEOVER,
        EMPTY
    }
}