using System;
using UnityEngine;
using System.Collections;

public class ManagerPlayerMaster : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private GameObject playerGoal;
    private Renderer playerRenderer;
    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;
    private Mgr_PlayerKeyCtrl mgrPlayerKeyCtrl;
    private Mgr_FadeImage mgrFadeImage;
    private Mgr_GameSE02 mgrGameSE02;
    private Mgr_MzTextTimer mgrMzTextTimer;

    private event EveHandToPlayer playerCtrlOn;

    private event EveHandToPlayer playerCtrlOff;

    private event EveHandPlayerValue playerMaxFSpeedUp;

    private event EveHandPlayerValue playerMaxBSpeedUp;

    private event EveHandPlayerValue playerMaxRotSpeedUp;

    private event EveHandPlayerValue playerKeySpeedUp;

    private event EveHandPlayerValue playerKeyRotSpeedUp;

    private event EveHandPLAYSE caughtByEnemySE;

    private event EveHandFadeImage toStartFadeWhite;

    private event EveHandFadeImage toReturnFadeWhite;

    private event EveHandMzTimer stopMzTimer;

    private event EveHandMzTimer startMzTimer;

    private event EveHandMzTimeUpDown reduseMzTimer;

    void Awake() {
        mgrPlayerBtnCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnCtrl>();
        mgrPlayerKeyCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerKeyCtrl>();
        playerRenderer = GameObject.FindWithTag("Player").GetComponent<MeshRenderer>();
        playerGoal = GameObject.Find("PlayerGoal");
        mgrFadeImage = GameObject.Find("Mgr_FadeImage").GetComponent<Mgr_FadeImage>();
        mgrGameSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
        mgrMzTextTimer = GameObject.Find("Mgr_MzTimer").GetComponent<Mgr_MzTextTimer>();
    }

    void Start() {
        playerGoal.gameObject.SetActive(false);
        playerRenderer.enabled = false;

        playerCtrlOn += new EveHandToPlayer(mgrPlayerBtnCtrl.CtrlChangeToKey);
        playerCtrlOn += new EveHandToPlayer(mgrPlayerKeyCtrl.CtrlChangeToKey);

        playerCtrlOff += new EveHandToPlayer(mgrPlayerBtnCtrl.CtrlChangeToKey);
        playerCtrlOff += new EveHandToPlayer(mgrPlayerKeyCtrl.CtrlChangeToBtn);

        playerMaxFSpeedUp += new EveHandPlayerValue(mgrPlayerBtnCtrl.PlayerMaxFSpeedChange);
        playerMaxBSpeedUp += new EveHandPlayerValue(mgrPlayerBtnCtrl.PlayerMaxBSpeedChange);
        playerMaxRotSpeedUp += new EveHandPlayerValue(mgrPlayerBtnCtrl.PlayerMaxRotSpeedChange);
        playerKeySpeedUp += new EveHandPlayerValue(mgrPlayerKeyCtrl.PlayerKeySpeedChange);
        playerKeyRotSpeedUp += new EveHandPlayerValue(mgrPlayerKeyCtrl.PlayerKeyRotSpeedChange);

        caughtByEnemySE += new EveHandPLAYSE(mgrGameSE02.SEEnemyTouch01Event);
        toStartFadeWhite += new EveHandFadeImage(mgrFadeImage.StartFadeWhite);
        toReturnFadeWhite += new EveHandFadeImage(mgrFadeImage.ReturnFadeWhite);

        reduseMzTimer += new EveHandMzTimeUpDown(mgrMzTextTimer.MzTimerCountValue);
        stopMzTimer += new EveHandMzTimer(mgrMzTextTimer.MzTimerStop);
        startMzTimer += new EveHandMzTimer(mgrMzTextTimer.MzTimerStart);
    }

    private IEnumerator WarpToStart() {
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(-1.0f, 0.5f, -15.0f);
        yield return new WaitForSeconds(2.0f);
        yield return null;
    }

    public void PlayerCtrlOn(object o, EventArgs e) {
        this.playerCtrlOn(this, EventArgs.Empty);
    }

    public void PlayerCtrlOff(object o, EventArgs e) {
        this.playerCtrlOff(this, EventArgs.Empty);
    }

    public void PlayerGetCroquette(object o, EventArgs e) {
        this.playerMaxFSpeedUp(this, 1.0f);
        this.playerMaxBSpeedUp(this, 0.5f);
        this.playerMaxRotSpeedUp(this, 0.2f);
        this.playerKeySpeedUp(this, 1.0f);
        this.playerKeyRotSpeedUp(this, 1);
    }

    public void EventPLAYING(object o, EventArgs e) {
        playerRenderer.enabled = false;
    }

    public void EventMAP(object o, EventArgs e) {
        playerRenderer.enabled = true;
    }

    public void EventGOAL(object o, EventArgs e) {
        player.gameObject.SetActive(false);
        playerGoal.gameObject.SetActive(true);
    }

    public void CaughtByEmyRobo(object o, EventArgs e) {
        this.playerCtrlOff(this, EventArgs.Empty);
        this.caughtByEnemySE(this, EventArgs.Empty);
        StartCoroutine(ReturnToStart());
    }

    IEnumerator ReturnToStart() {
        this.stopMzTimer(this, EventArgs.Empty);
        this.toStartFadeWhite(this, EventArgs.Empty);
        yield return new WaitForSeconds(3.0f);
        player.transform.position = new Vector3(-1.0f, 0.5f, -15.0f);
        this.reduseMzTimer(this, -30);
        this.toReturnFadeWhite(this, EventArgs.Empty);
        yield return new WaitForSeconds(3.0f);
        this.playerCtrlOn(this, EventArgs.Empty);
        this.startMzTimer(this, EventArgs.Empty);
    }
}