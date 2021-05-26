using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject controls;
    [SerializeField] GameObject page;
    [SerializeField] Text textFull;
    [SerializeField] GameObject inputField;
    private bool controlsEnabled = false;

    private string finalWordAssigned = "";
    private int finalWordIndex = 0;
    private List<string> listFinalWords = new List<string>();
    private List<string> listFinalPages = new List<string>();
    private List<bool> listNPCType = new List<bool>();
    
    #region Fill data
    private void fillLists(){
        listFinalWords.Add("death");
        listNPCType.Add(true);
        listFinalPages.Add("Esta es la lista de copras \n Esta es la linea 2\n y la linea 3");

        listFinalWords.Add("love");
        listNPCType.Add(false);
        listFinalPages.Add("Esta es la lista de copras \n Esta es la linea 2\n y la linea 3");

        listFinalWords.Add("kill");
        listNPCType.Add(true);
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
        page.SetActive(true);
        inputField.SetActive(true);

        //textFull.text = listFinalPages[finalWordIndex];
        finalWordAssigned = listFinalWords[finalWordIndex];
    }

    

    private void HidePage() {

        inputField.SetActive(false);
        page.SetActive(false);

        string sceneToOpen = checkAnswer(finalWordAssigned,getTextFromInput(),listNPCType[finalWordIndex]);
        openScene(sceneToOpen);
        finalWordIndex++;
    }

    #endregion

    #region Annagram functions
    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
    
    }
    

    private string getTextFromInput(){
        GameObject inputFieldGo = inputField;
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        return inputFieldCo.text ;
    }

    // Check if the word in the inputField is the finalWord
    public string checkAnswer(string finalWord, string word, bool npcType){
        
        // Clean text
        word.Replace(" ","");
        word.Replace("\n","");
        
        if(word == finalWord){
            if(npcType){
                return "Mato Asesino";
            }
            else{
                return "Perdono NPC";
            }
        }
        else{
            if(npcType){
                return "Perdono Asesino";
            }
            else{
                return "Mato NPC";
            }
        }
        return "";
    }

    #endregion

    #region Controls

    private void openScene(string scene){

    }

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

    #endregion
}
