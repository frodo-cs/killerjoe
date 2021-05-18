using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject controls;
    [SerializeField] GameObject menu;

    private bool controlsEnabled = false;

    private void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;
    }

    private void Update() {
        controls.SetActive(controlsEnabled);
        menu.SetActive(!controlsEnabled);
    }

    public void Controls() {
        controlsEnabled = !controlsEnabled;
    }

    public void Play() {
        SceneManager.LoadScene("Story");
    }
}
