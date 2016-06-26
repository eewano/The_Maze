using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public delegate void EventHandler(object sender, EventArgs e);

public class EventDeleteText : MonoBehaviour {

    [SerializeField]
    private GameObject buttonDeleteText;
    [SerializeField]
    private Mz00ItemGet mz00ItemGet;

    public event EventHandler textDelete;

    void Start() {
        buttonDeleteText.gameObject.SetActive(false);
        textDelete += new EventHandler(mz00ItemGet.ImageDeleteHandler);
    }

    public void AppearObject(object o, EventArgs e) {
        buttonDeleteText.gameObject.SetActive(true);
    }

    public void OnButtonDeleteClicked() {
        this.textDelete(this, EventArgs.Empty);
        buttonDeleteText.gameObject.SetActive(false);
    }
}
