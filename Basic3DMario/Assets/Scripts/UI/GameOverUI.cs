using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverReasonText;


    private void Start() {
        GameManager.Instance.OnGameOver += ShowGameOverUI;
        gameObject.SetActive(false);
    }

    private void ShowGameOverUI(object sender, System.EventArgs e) { 
        scoreText.text = "You have " + GameManager.Instance.Score + " points!";
        gameOverReasonText.text = "Game Over: " + GameManager.Instance.GameOverReason;
        gameObject.SetActive(true);
    }
}
