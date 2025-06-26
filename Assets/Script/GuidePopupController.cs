using UnityEngine;

public class GuidePopupController : MonoBehaviour
{
    public GameObject popupImage; // Gambar yang akan muncul sebagai popup

    public void ShowPopup()
    {
        popupImage.SetActive(true);
    }

    public void HidePopup()
    {
        popupImage.SetActive(false);
    }
}
