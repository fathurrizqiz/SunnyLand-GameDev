using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Ganti scene langsung dengan nama
    public void ChangeScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    // Pause game
    public void Paused()
    {
        Time.timeScale = 0;
    }

    // Lanjutkan game
    public void Resume()
    {
        Time.timeScale = 1;
    }

    // Retry / Restart level
    public void Retry()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.isReviving = false; // Reset flag revive
            GameManager.instance.RestartLevel();     // Restart level dan reset skor
        }
        else
        {
            Debug.LogWarning("GameManager tidak ditemukan saat retry.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // fallback
        }
    }

    // Kembali ke menu utama
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }

    // Panggil revive (akan konfirmasi dulu di GameManager)
    public void Revive()
    {
        if (GameManager.instance != null)
        {
            // GameManager.instance.isReviving = false;
            GameManager.instance.Revive(); // Tampilkan konfirmasi revive
        }
        else
        {
            Debug.LogWarning("GameManager tidak ditemukan saat revive.");
        }
    }
}
