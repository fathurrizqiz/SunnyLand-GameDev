using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int levelNumber; // Misal: 1, 2, 3, dst.
    public Button levelButton;
    public GameObject lockIcon; // icon gembok

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("LevelUnlocked", 1);

        bool isUnlocked = levelNumber <= unlockedLevel;

        levelButton.interactable = isUnlocked;
        lockIcon.SetActive(!isUnlocked);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level " + levelNumber);
    }
}
