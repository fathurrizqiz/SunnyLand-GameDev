using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // untuk ganti scene
using UnityEngine.UI; // jika ingin mengakses Button

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject targetPanel; // <- Tambahkan ini
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
            Debug.Log("target tercapai");
            targetPanel.SetActive(true); // tampilkan panel
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }

    public void NextLevel()
    {
        // Ganti dengan nama scene berikutnya
        SceneManager.LoadScene("Level 3");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1; // Pastikan waktu berjalan normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene saat ini
        score = 0; // Reset skor jika perlu
        UpdateScoreUI(); // Perbarui UI skor
    }
    public void Revive()
{
    if (score >= 10)
    {
        if (lives > 0)
        {
            Debug.Log("Revive diproses.");

            // Kurangi score
            score -= 10;
            UpdateScoreUI();

            // Kurangi nyawa
            lives--;

            // Aktifkan player kembali
            player.SetActive(true);

            // Pindahkan ke posisi spawn
            player.transform.position = spawnPoint.position;

            // Pastikan waktu normal
            Time.timeScale = 1;

            Debug.Log($"Player di-revive. Sisa nyawa: {lives}, score: {score}");
        }
        else
        {
            Debug.Log("Nyawa habis, game over.");
            ShowGameOver();
        }
    }
    else
{
    Debug.Log("Score tidak cukup untuk revive.");
    ShowNotEnoughPoints();
}

}

public void ShowNotEnoughPoints()
{
    if (notEnoughPointsPanel != null)
    {
        notEnoughPointsPanel.SetActive(true);
        Time.timeScale = 0; // opsional: pause agar pemain bisa baca
    }
    else
    {
        Debug.LogWarning("Panel 'notEnoughPointsPanel' belum diset di GameManager.");
    }
}

public void ShowGameOver()
{
    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // pause game
    }
    else
    {
        Debug.LogWarning("GameOverPanel belum diset.");
    }
}



}