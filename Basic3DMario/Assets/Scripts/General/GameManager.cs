using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        Playing, 
        GameOver
    }

    public static GameManager Instance { get; private set; }

    public GameState State { get; private set;}


    public event EventHandler OnGameOver;
    public event EventHandler OnScoreChanged;

    public int Score { get; private set; }
    public string GameOverReason { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            throw new System.Exception("There is already a GameManager instance");
        }
    }

    public void GameOver(string reason) { 
        State = GameState.GameOver;
        GameOverReason = reason;
        OnGameOver?.Invoke(this, EventArgs.Empty);
        Time.timeScale = 0f;
    }

    public void AddScore(int score) {
        Score += score;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }
}
