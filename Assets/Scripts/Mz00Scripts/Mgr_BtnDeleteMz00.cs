using System;
using UnityEngine;

public class Mgr_BtnDeleteMz00 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonDeleteMz00;
    private Mgr_Mz00ItemGet mgrMz00ItemGet;
    private Mz00ClearFlag mz00ClearFlag;

    private bool allItemGet;

    public event EveHandDeleteText textDeleteMz00;

    private event EveHandFlagItem mz00ItemGet;

    void Awake() {
        mgrMz00ItemGet = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_Mz00ItemGet>();
        mz00ClearFlag = GameObject.Find("Mz00ClearFlag").GetComponent<Mz00ClearFlag>();
    }

    void Start() {
        allItemGet = false;
        buttonDeleteMz00.gameObject.SetActive(false);
        textDeleteMz00 += new EveHandDeleteText(mgrMz00ItemGet.ImageTextDelete);
        mz00ItemGet += new EveHandFlagItem(mz00ClearFlag.ReduceItemCount);
    }

    public void AppearObject(object o, EventArgs e) {
        buttonDeleteMz00.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnButtonDeleteClicked() {
        Time.timeScale = 1;
        this.textDeleteMz00(this, EventArgs.Empty);
        if (allItemGet == false)
        {
            this.mz00ItemGet(this, EventArgs.Empty);
        }
        buttonDeleteMz00.gameObject.SetActive(false);
    }

    public void AllItemGet(object o, EventArgs e) {
        allItemGet = true;
    }
}
