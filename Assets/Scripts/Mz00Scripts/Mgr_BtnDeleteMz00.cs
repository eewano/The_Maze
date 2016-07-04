using System;
using UnityEngine;

public class Mgr_BtnDeleteMz00 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonDeleteMz00;
    private Mgr_Mz00ItemGet mgrMz00ItemGet;

    public event EveHandDeleteText textDeleteMz00;

    void Awake() {
        mgrMz00ItemGet = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_Mz00ItemGet>();
    }

    void Start() {
        buttonDeleteMz00.gameObject.SetActive(false);
        textDeleteMz00 += new EveHandDeleteText(mgrMz00ItemGet.ImageTextDelete);
    }

    public void AppearObject(object o, EventArgs e) {
        buttonDeleteMz00.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnButtonDeleteClicked() {
        Time.timeScale = 1;
        this.textDeleteMz00(this, EventArgs.Empty);
        buttonDeleteMz00.gameObject.SetActive(false);
    }
}
