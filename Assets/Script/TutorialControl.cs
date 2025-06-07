using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    public GameObject panelTutorial;

    void Start()
    {
        // Nampilin tutorial pas game dimulai
        panelTutorial.SetActive(true);

        // Pause game
        Time.timeScale = 0f;
    }

    public void CloseTutorial()
    {
        // Sembunyiin panel tutorial
        panelTutorial.SetActive(false);

        // Lanjutin game
        Time.timeScale = 1f;
    }
}
