using System;
using UnityEngine;
using TMPro;

public class ScoreManager1 : MonoBehaviour
{
    private int score = 0; // スコア

    [SerializeField]
    private TMPro.TMP_Text scoreText; // TextMeshProテキストコンポーネント

    private void Start()
    {
        // スコアの初期化
        score = 0;
    }

    public void IncreaseScore()
    {
        score += 1;
    }
    private void Update()
    {
        // TextMeshProテキストにスコアを表示
        scoreText.text = "Score: " + score.ToString();
    }
}