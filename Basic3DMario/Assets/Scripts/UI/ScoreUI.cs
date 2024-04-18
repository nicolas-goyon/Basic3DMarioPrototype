using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreNumber;
    [SerializeField] private float baseScoreSize = 50;
    [SerializeField] private float scoreSizeMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        
    }

    private void OnScoreChanged(object sender, System.EventArgs e) {
        scoreNumber.text = GameManager.Instance.Score.ToString();
        scoreNumber.fontSize = baseScoreSize + GameManager.Instance.Score * scoreSizeMultiplier;
    }
}
