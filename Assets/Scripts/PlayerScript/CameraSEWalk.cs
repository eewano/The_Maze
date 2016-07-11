using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSEWalk : MonoBehaviour {

    private Mgr_GameSEFoot mgrGameSEFoot;

    private event EveHandPLAYSE playSEMz00Walk;

    private event EveHandPLAYSE playSEMz01Walk;

    private event EveHandPLAYSE playSEMz02Walk;

    private event EveHandPLAYSE playSEMz03Walk;

    void Awake() {
        mgrGameSEFoot = GameObject.Find("Mgr_GameSEFoot").GetComponent<Mgr_GameSEFoot>();
    }

    void Start() {
        playSEMz00Walk += new EveHandPLAYSE(mgrGameSEFoot.SEMz00WalkEvent);
        playSEMz01Walk += new EveHandPLAYSE(mgrGameSEFoot.SEMz01WalkEvent);
        playSEMz02Walk += new EveHandPLAYSE(mgrGameSEFoot.SEMz02WalkEvent);
        playSEMz03Walk += new EveHandPLAYSE(mgrGameSEFoot.SEMz00WalkEvent);
    }

    public void StartWalking(object o, EventArgs e) {
        if (SceneManager.GetActiveScene().name == "Maze00")
        {
            this.playSEMz00Walk(this, EventArgs.Empty);
        }
        else if (SceneManager.GetActiveScene().name == "Maze01")
        {
            this.playSEMz01Walk(this, EventArgs.Empty);
        }
        else if (SceneManager.GetActiveScene().name == "Maze02")
        {
            this.playSEMz02Walk(this, EventArgs.Empty);
        }
        else if (SceneManager.GetActiveScene().name == "Maze03")
        {
            this.playSEMz03Walk(this, EventArgs.Empty);
        }
    }
}