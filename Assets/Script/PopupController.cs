using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject[] tutorialSteps;  // Tambahan: array semua langkah/tutorial
    private int currentStep = 0;

    public void ShowPopup()
    {
        Debug.Log("ShowPopup() called");
        popupPanel.SetActive(true);
        ShowStep(0); // Mulai dari step 0 setiap kali dibuka
    }

    public void HidePopup()
{
    Debug.Log("HidePopup() called");
    popupPanel.SetActive(false);
}


    public void NextStep()
    {
        if (currentStep < tutorialSteps.Length - 1)
        {
            currentStep++;
            ShowStep(currentStep);
        }
    }

    public void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            ShowStep(currentStep);
        }
    }

    private void ShowStep(int index)
    {
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == index);
        }
    }
}
