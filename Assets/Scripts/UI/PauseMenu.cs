using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject controls;
    private bool controlsEnabled = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !Player.SolvingPuzzle && !controlsEnabled) {
            SetPause(!GamePaused);
        }
    }

    private void SetPause(bool b) {
        SetVisibily(true, false);
    }

    public void Controls() {
        SetVisibily(false, true);
    }

    public void Back() {
        SetVisibily(true, false);
    }

    public void Resume() {
        SetVisibily(false, false);
    }

    private void SetVisibily(bool p, bool c) {
        Cursor.visible = !p ^ !c;
        GUI.SetActive(!p && !c);
        pauseUI.SetActive(p && !c);
        controls.SetActive(!p && c);
        Time.timeScale = p || c ? 0f : 1f;
        GamePaused = p && c;
    }

    public void Menu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
