using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static GameEvents current;
    private void Awake() {
        current = this;
    }

    public event Action OnGameWon;
    public event Action OnGameLostTime;
    public event Action OnGameLostAssassin;
    public event Action OnGameLostBoss;
    public event Action OnNPCDestroyed;
    public event Action OnPuzzleSolved;
    public event Action OnPayingPosition;

    public void GameWonTrigger() {
        if (OnGameWon != null) {
            OnGameWon.Invoke();
        }
    }

    public void PayingPositionTrigger() {
        if (OnPayingPosition != null) {
            OnPayingPosition.Invoke();
        }
    }

    public void GameLostTimeTrigger() {
        if (OnGameLostTime != null) {
            OnGameLostTime.Invoke();
        }
    }

    public void GameLostAssasinTrigger() {
        if (OnGameLostAssassin != null) {
            OnGameLostAssassin.Invoke();
        }
    }

    public void GameLostBossTrigger() {
        if (OnGameLostBoss != null) {
            OnGameLostBoss.Invoke();
        }
    }

    public void NPCDestroyedTrigger() {
        if(OnNPCDestroyed != null) {
            OnNPCDestroyed.Invoke();
        }
    }

    public void PuzzleSolvedTrigger() {
        if(OnPuzzleSolved != null) {
            OnPuzzleSolved.Invoke();
        }
    }
}
