using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleSolve : MonoBehaviour {

    public static PuzzleSolve puzzleSolve;

    public TextMeshProUGUI textSolved;

    public int finalWordIndex;

    private void Awake() {
        if(puzzleSolve == null) {
            DontDestroyOnLoad(gameObject);
            puzzleSolve = this;
        } else if (puzzleSolve != this){
            Destroy(gameObject);
        }    
    }

    private void Start() {
        textSolved = GameObject.FindGameObjectWithTag("Solved").GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if(textSolved == null && SceneManager.GetActiveScene().name == "Game")
            textSolved = GameObject.FindGameObjectWithTag("Solved").GetComponent<TextMeshProUGUI>();
        textSolved.text = $"Solved: {finalWordIndex}";
    }

}
