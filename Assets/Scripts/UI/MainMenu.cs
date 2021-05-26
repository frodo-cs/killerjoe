using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject controls;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject menu;

    bool controlsEnabled = false;
    bool creditsEnabled = false;

    private void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;

    }

    private void Update() {
        controls.SetActive(controlsEnabled && !creditsEnabled);
        credits.SetActive(creditsEnabled && !controlsEnabled);
        menu.SetActive(!controlsEnabled && !creditsEnabled);
    }

    public void Controls() {
        controlsEnabled = true;
        creditsEnabled = false;
    }

    public void Credits() {
        creditsEnabled = true;
        controlsEnabled = false;
    }

    public void Back() {
        creditsEnabled = false;
        controlsEnabled = false;
    }

    public void Play() {
        SceneManager.LoadScene("Story");
    }
}
