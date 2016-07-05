using System;
using System.Collections;
using UnityEngine;

public class Mz00ClearFlag : MonoBehaviour {

    private Mgr_Mz00ItemGet mgrMz00ItemGet;
    private Mgr_BtnDeleteMz00 mgrBtnDeleteMz00;
    private Mz00WallClearFlag mz00WallClearFlag;
    private int itemLeft;

    private event EveHandFlagItem allItemGet;

    void Awake() {
        mgrMz00ItemGet = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_Mz00ItemGet>();
        mgrBtnDeleteMz00 = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_BtnDeleteMz00>();
        mz00WallClearFlag = GameObject.Find("Mz00WallClearFlag").GetComponent<Mz00WallClearFlag>();
    }

    void Start() {
        itemLeft = 3;
        allItemGet += new EveHandFlagItem(mgrMz00ItemGet.Mz00ClearFlag);
        allItemGet += new EveHandFlagItem(mgrBtnDeleteMz00.AppearObject);
        allItemGet += new EveHandFlagItem(mgrBtnDeleteMz00.AllItemGet);
        allItemGet += new EveHandFlagItem(mz00WallClearFlag.DeleteWall);
    }

    public void ReduceItemCount(object o, EventArgs e) {
        itemLeft -= 1;
        if (itemLeft <= 0) {
            StartCoroutine(ClearFlag());
            return;
        }
    }

    IEnumerator ClearFlag() {
        yield return new WaitForSeconds(0.2f);
        this.allItemGet(this, EventArgs.Empty);
    }
}