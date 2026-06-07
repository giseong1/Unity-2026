using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    public int maxLives = 3;
    private int currentLives;
    private int currentScore = 0;

    
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    private bool isDying = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentLives = maxLives;
            currentScore = 0;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        FindAndRefreshUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (Instance == this)
        {
            FindAndRefreshUI();
        }
    }

    void FindAndRefreshUI()
    {
        GameObject livesObj = GameObject.Find("LivesText");
        if (livesObj != null)
        {
            livesText = livesObj.GetComponent<TextMeshProUGUI>();
        }

        GameObject scoreObj = GameObject.Find("ScoreText");
        if (scoreObj != null)
        {
            scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
        }

        isDying = false;

        UpdateUI();
    }

    public void LoseLife()
    {
        if (isDying) return;
        isDying = true;

        currentLives--;
        UpdateUI();

        if (currentLives > 0)
        {
            Debug.Log("목숨을 잃었습니다.");
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("게임 오버!");
        
        SceneManager.LoadScene("FailScene");
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString("D3");
        }
    }
}