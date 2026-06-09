using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentLives = 3;
    private int currentScore = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    private float lastHitTime;

    void Start()
    {
        Instance = this;

        UpdateUI();
    }

    // 점수 추가
    public void AddScore(int score)
    {
        currentScore += score;
        UpdateUI();
    }

    // 목숨 감소
    public void LoseLife()
    {
        if (Time.time - lastHitTime < 0.3f) return;
        lastHitTime = Time.time;

        currentLives--;

        UpdateUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    // 게임 오버
    void GameOver()
    {
        SceneManager.LoadScene("FailScene");
    }

    // UI 갱신
    void UpdateUI()
    {
        livesText.text = "Lives: " + currentLives;
        scoreText.text = "Score: " + currentScore.ToString("D3");
    }
}