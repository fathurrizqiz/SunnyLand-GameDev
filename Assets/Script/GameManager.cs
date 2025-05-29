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
}
