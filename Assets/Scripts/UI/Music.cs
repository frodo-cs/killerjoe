using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    public static Music music;
    AudioSource source;

    private void Awake() {
        if (music == null) {
            DontDestroyOnLoad(gameObject);
            music = this;
        } else if (music != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        source = GetComponent<AudioSource>();
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name != "Game" && SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "HowTo" && SceneManager.GetActiveScene().name != "Story") {
            source.volume = 0.03f;
        } else {
            source.volume = 0.1f;
        }
    }
}
