using UnityEngine;
using TMPro;

public class LeaderboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText;

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        int total = PlayerPrefs.GetInt("TotalScore", 0);
        totalScoreText.text = "Total Score: " + total;
    }
}
