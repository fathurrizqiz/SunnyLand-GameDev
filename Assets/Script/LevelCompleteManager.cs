using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    public int currentLevel; 

    public void LevelComplete()
    {
        int unlockedLevel = PlayerPrefs.GetInt("LevelUnlocked", 1);

        if (currentLevel >= unlockedLevel)
        {
            PlayerPrefs.SetInt("LevelUnlocked", currentLevel + 1);
            PlayerPrefs.Save();
        }

        
        SceneManager.LoadScene("LevelSelectorScene");
    }
}
