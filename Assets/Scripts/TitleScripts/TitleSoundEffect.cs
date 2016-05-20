using UnityEngine;
using System.Collections;

public class TitleSoundEffect : MonoBehaviour {

    private AudioSource EnterSE;
    private AudioSource ExitSE;

    void Start() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        EnterSE = audioSources[0];
        ExitSE = audioSources[1];
    }

    public void Enter() {
        EnterSE.PlayOneShot(EnterSE.clip);
    }

    public void Exit() {
        ExitSE.PlayOneShot(ExitSE.clip);
    }

    public void GameEnter() {
        EnterSE.PlayOneShot(EnterSE.clip);
    }
}