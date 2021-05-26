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


    #region Fill data
    private void fillLists() {
        listFinalWords.Add("death");
        listNPCType.Add(true);
        listFinalPages.Add("Esta es la lista de copras \n Esta es la linea 2\n y la linea 3");

        listFinalWords.Add("love");
        listNPCType.Add(false);
        listFinalPages.Add("Esta es la lista de copras \n Esta es la linea 2\n y la linea 3");

    }

    #endregion

    #region Trigger functions
    private void Start() {
        GameEvents.current.OnPuzzleSolved += HidePage;
        GameEvents.current.OnPayingPosition += ShowPage;

        fillLists();
    }

    private void ShowPage() {
        puzzle = GameObject.FindGameObjectWithTag("Puzzle").GetComponent<PuzzleSolve>();
        if(puzzle.finalWordIndex < listFinalWords.Count) {
            Cursor.visible = true;
            page.SetActive(true);
            inputField.SetActive(true);
            Player.SolvingPuzzle = true;
            textFull.text = listFinalPages[puzzle.finalWordIndex];
            finalWordAssigned = listFinalWords[puzzle.finalWordIndex];
        }
        Debug.Log($"{puzzle.finalWordIndex} {listNPCType.Count}");
    }



    private void HidePage() {

        inputField.SetActive(false);
        page.SetActive(false);
        string sceneToOpen = checkAnswer(finalWordAssigned, getTextFromInput(), listNPCType[puzzle.finalWordIndex], puzzle.finalWordIndex == listNPCType.Count-1);
        if (sceneToOpen != "None")
            openScene(sceneToOpen);
        Cursor.visible = false;
        Player.SolvingPuzzle = false;
        puzzle.finalWordIndex++;
        inputField.GetComponent<InputField>().text = "";
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
            if (npcType) {
                return "CajeroMataAsesino";
            } else if (boss) {
                return "CajeroMataJefe";
            } else {
                return "None";
            }
        } else {
            if (npcType) {
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
        if (Input.GetKeyDown(KeyCode.Escape) && !Player.SolvingPuzzle) {
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
