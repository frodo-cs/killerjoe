using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject page;
    [SerializeField] TextMeshProUGUI textFull;
    [SerializeField] GameObject inputField;
    [SerializeField] PuzzleSolve puzzle;

    private string finalWordAssigned = "";
    private List<string> listFinalWords = new List<string>();
    private List<string> listFinalPages = new List<string>();
    private List<bool> listNPCType = new List<bool>();
    AnagramGenerator generator = new AnagramGenerator();

    #region Trigger functions
    private void Start() {
        GameEvents.current.OnPuzzleSolved += HidePage;
        GameEvents.current.OnPayingPosition += ShowPage;
        generator.loadWords();
        listFinalWords = generator.finalWords;
        listNPCType = generator.npcTypes;
        listFinalPages = generator.finalPages;

    }

    private void ShowPage() {
        puzzle = GameObject.FindGameObjectWithTag("Puzzle").GetComponent<PuzzleSolve>();
        if (puzzle.finalWordIndex < listFinalWords.Count) {
            Cursor.visible = true;
            page.SetActive(true);
            inputField.SetActive(true);
            Game.SolvingPuzzle = true;
            textFull.text = listFinalPages[puzzle.finalWordIndex];
            finalWordAssigned = listFinalWords[puzzle.finalWordIndex];
        }

    }

    private void HidePage() {

        inputField.SetActive(false);
        page.SetActive(false);
        puzzle.finalWordIndex++;
        string sceneToOpen = checkAnswer(finalWordAssigned, getTextFromInput(), listNPCType[puzzle.finalWordIndex-1], puzzle.finalWordIndex == listNPCType.Count);
        inputField.GetComponent<InputField>().text = "";
        Game.SolvingPuzzle = false;
        if (sceneToOpen != "None")
            openScene(sceneToOpen);     
    }

    #endregion

    #region Annagram functions
    public void loadlevel(string level) {
        SceneManager.LoadScene(level);

    }


    private string getTextFromInput() {
        GameObject inputFieldGo = inputField;
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        return inputFieldCo.text.Replace(" ", "");
    }

    // Check if the word in the inputField is the finalWord
    public string checkAnswer(string finalWord, string word, bool npcType, bool boss) {
        // Clean text
        word.Replace(" ", "");
        word.Replace("\n", "");

        if (word == finalWord) {
            if (npcType && !boss) {
                return "CajeroMataAsesino";
            } else if (boss) {
                return "CajeroMataJefe";
            } else {
                return "None";
            }
        } else {
            if (npcType && !boss) {
                return "CajeroPerdonaAsesino";
            } else if (boss) {
                return "CajeroPerdonaJefe";
            } else {
                return "CajeroMataCliente";
            }
        }
    }

    #endregion

    #region Controls

    private void openScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !Game.SolvingPuzzle) {
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
        Time.timeScale = p || c ? 0f : 1f;
        GamePaused = p && c;
    }

    public void Menu() {
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        Destroy(GameObject.FindGameObjectWithTag("Puzzle"));
        SceneManager.LoadScene("Menu");
    }

    #endregion
}
