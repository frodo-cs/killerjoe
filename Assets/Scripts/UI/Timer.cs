using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour {

    [SerializeField] float maxTime;
    [SerializeField] TextMeshProUGUI textTime;

    float time = 10;
    bool timerOn = false;

    private void Start() {
        GameEvents.current.OnPuzzleSolved += ResetTimer;
        GameEvents.current.OnPayingPosition += StartTimer;
        time = maxTime;
        textTime.text = "";
    }

    private void StartTimer() {
        timerOn = true;
        textTime.text = $"{maxTime}";
    }

    private void ResetTimer() {
        timerOn = false;
        time = maxTime;
        textTime.text = "";
    }

    private void Update() {
        if(timerOn && time > 0) {
            time -= Time.deltaTime;
            textTime.text = string.Format("Time Left: {0}", time.ToString("0"));
        } else if (time <= 0) {
            textTime.text = "0";
            GameEvents.current.GameLostTrigger();
        }
    }
}
