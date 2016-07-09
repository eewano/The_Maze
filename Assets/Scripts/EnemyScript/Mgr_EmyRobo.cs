using System;
using UnityEngine;

public class Mgr_EmyRobo : MonoBehaviour {

    [SerializeField]
    private EnemyMove enemyRobo01;
    [SerializeField]
    private EnemyMove enemyRobo02;

    private event EveHandMgrState enemyMoveON;

    private event EveHandMgrState enemyMoveOFF;

    void Start() {
        enemyMoveON += new EveHandMgrState(enemyRobo01.MovingStart);
        enemyMoveON += new EveHandMgrState(enemyRobo02.MovingStart);

        enemyMoveOFF += new EveHandMgrState(enemyRobo01.MovingStop);
        enemyMoveOFF += new EveHandMgrState(enemyRobo02.MovingStop);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.enemyMoveON(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.enemyMoveOFF(this, EventArgs.Empty);
    }
}
