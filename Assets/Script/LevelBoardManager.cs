using UnityEngine;
using TMPro;

public class LevelBoardManager : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText;

    void Start()
    {
        // Ambil skor dari PlayerPrefs
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        totalScoreText.text = "Total Skor: " + totalScore.ToString();
    }
}
