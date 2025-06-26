using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject targetPanel;
    public bool isReviving = false;
    public GameObject player;
    public Transform spawnPoint;
    public GameObject notEnoughPointsPanel;
    public int lives = 3;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;

        if (score == 29)
        {
            Debug.Log("Target tercapai!");
            targetPanel.SetActive(true);
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }

    public void NextLevel()
    {
        // Opsional: buka level berikutnya secara otomatis
        int currentLevel = GetCurrentLevelNumber();
        CompleteLevel(currentLevel);

        // Ganti dengan nama scene berikutnya sesuai penamaanmu
        SceneManager.LoadScene("Level " + (currentLevel + 1));
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score = 0;
        UpdateScoreUI();
    }

    public void Revive()
    {
        if (score >= 10)
        {
            if (lives > 0)
            {
                Debug.Log("Revive diproses.");

                score -= 10;
                lives--;
                UpdateScoreUI();

                HealthUI health = player.GetComponentInChildren<HealthUI>();
                if (health != null)
                {
                    health.ResetHealth();
                    Debug.Log("HP di-reset ke full.");
                }
                else
                {
                    Debug.LogWarning("Komponen HealthUI tidak ditemukan saat revive.");
                }

                player.transform.position = spawnPoint.position;
                player.SetActive(true);

                Time.timeScale = 1;
                Debug.Log($"Player di-revive. Sisa nyawa: {lives}, skor: {score}");
            }
            else
            {
                Debug.Log("Nyawa habis, game over.");
                ShowGameOver();
            }
        }
        else
        {
            Debug.Log("Skor tidak cukup untuk revive.");
            ShowNotEnoughPoints();
        }
    }

    public void ShowNotEnoughPoints()
    {
        if (notEnoughPointsPanel != null)
        {
            notEnoughPointsPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Debug.LogWarning("Panel 'notEnoughPointsPanel' belum diset.");
        }
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Debug.LogWarning("Panel GameOver belum diset.");
        }
    }

    // 🔓 Unlock level berikutnya setelah menyelesaikan level saat ini
    public void CompleteLevel(int levelNumber)
{
    int highestUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
    Debug.Log("CompleteLevel dipanggil. current=" + levelNumber + ", highestUnlocked=" + highestUnlocked);

    if (levelNumber >= highestUnlocked)
    {
        PlayerPrefs.SetInt("LevelUnlocked", levelNumber + 1);
        PlayerPrefs.Save();
        Debug.Log("Level " + (levelNumber + 1) + " berhasil dibuka!");
    }
}


    // 🔍 Deteksi level saat ini berdasarkan nama scene
    int GetCurrentLevelNumber()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // Misal scene bernama "Level 1", "Level 2", dst.
        if (sceneName.StartsWith("Level "))
        {
            string numberPart = sceneName.Substring(6);
            if (int.TryParse(numberPart, out int levelNum))
            {
                return levelNum;
            }
        }

        Debug.LogWarning("Nama scene saat ini tidak sesuai format 'Level X'");
        return 1; // fallback ke level 1
    }
}
