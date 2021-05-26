using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject credits;
    [SerializeField] GameObject menu;

    bool creditsEnabled = false;

    private void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;

    }

    private void Update() {
        credits.SetActive(creditsEnabled);
        menu.SetActive(!creditsEnabled);
    }

    public void Credits() {
        creditsEnabled = true;
    }

    public void Back() {
        creditsEnabled = false;
    }

    public void Play() {
        SceneManager.LoadScene("Story");
    }
}
