using System;
using UnityEngine;

public class Mgr_Enemy : MonoBehaviour {

    [SerializeField]
    private EnemyRoboMove enemy01;
    [SerializeField]
    private EnemyRoboMove enemy02;

    private event EveHandMgrState enemyMoveON;

    private event EveHandMgrState enemyMoveOFF;

    void Start() {
        enemyMoveON += new EveHandMgrState(enemy01.MovingStart);
        enemyMoveON += new EveHandMgrState(enemy02.MovingStart);

        enemyMoveOFF += new EveHandMgrState(enemy01.MovingStop);
        enemyMoveOFF += new EveHandMgrState(enemy02.MovingStop);
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
