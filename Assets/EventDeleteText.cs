using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public delegate void EventHandler(object sender, EventArgs e);

public class EventDeleteText : MonoBehaviour {

    [SerializeField]
    private GameObject buttonDeleteText;

    public event EventHandler textDelete;

    void Start() {
        buttonDeleteText.gameObject.SetActive(false);
//                textDelete += new EventHandler();
    }

    public void AppearObject(object o, EventArgs e) {
        buttonDeleteText.gameObject.SetActive(true);
    }

    public void OnButtonDeleteClicked() {
        this.textDelete(this, EventArgs.Empty);
        buttonDeleteText.gameObject.SetActive(false);
    }
}
