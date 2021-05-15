using System;
using UnityEngine;


public class GameEvents : MonoBehaviour {
    public static GameEvents current;
    private void Awake() {
        current = this;
    }

    public event Action OnGameWon;
    public event Action OnGameLost;
    public event Action OnNPCDestroyed;

    public void GameWonTrigger() {
        if (OnGameWon != null) {
            OnGameWon.Invoke();
        }
    }

    public void GameLostTrigger() {
        if (OnGameLost != null) {
            OnGameLost.Invoke();
        }
    }

    public void NPCDestroyedTrigger() {
        if(OnNPCDestroyed != null) {
            OnNPCDestroyed.Invoke();
        }
    }
}
