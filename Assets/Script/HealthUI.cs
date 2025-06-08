using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class HealthUI : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Lose Panel")]
    public GameObject losePanel;

    [Header("Set 1 Layers (Top to Bottom)")]
    public GameObject healthLayer3_Set1;
    public GameObject healthLayer2_Set1;
    public GameObject healthLayer1_Set1;
    public GameObject healthLayer0_Set1;

    [Header("Set 2 Layers (Top to Bottom)")]
    public GameObject healthLayer3_Set2;
    public GameObject healthLayer2_Set2;
    public GameObject healthLayer1_Set2;
    public GameObject healthLayer0_Set2;

    [Header("Set 3 Layers (Top to Bottom)")]
    public GameObject healthLayer3_Set3;
    public GameObject healthLayer2_Set3;
    public GameObject healthLayer1_Set3;
    public GameObject healthLayer0_Set3;

    [Header("Set 4 Layers (Top to Bottom)")]
    public GameObject healthLayer3_Set4;
    public GameObject healthLayer2_Set4;
    public GameObject healthLayer1_Set4;
    public GameObject healthLayer0_Set4;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"Inisialisasi HealthUI pada GameObject: {gameObject.name}, Health: {currentHealth}/{maxHealth}");
        UpdateHealthLayers();

        // Pastikan losePanel dimatikan di awal
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log($"TakeDamage dipanggil dengan amount = {amount}");
        currentHealth = Mathf.Max(0, currentHealth - amount);
        Debug.Log($"Health sekarang: {currentHealth}/{maxHealth}");
        UpdateHealthLayers();

        if (currentHealth == 0)
        

        {
            Debug.Log("Game Over!");
            if (losePanel != null)
            {
                losePanel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Lose Panel belum diset di Inspector.");
            }
            Time.timeScale = 0f;
        }
    }

    void UpdateHealthLayers()
    {
        UpdateLayerSet(healthLayer3_Set1, healthLayer2_Set1, healthLayer1_Set1, healthLayer0_Set1, "Set 1");
        UpdateLayerSet(healthLayer3_Set2, healthLayer2_Set2, healthLayer1_Set2, healthLayer0_Set2, "Set 2");
        UpdateLayerSet(healthLayer3_Set3, healthLayer2_Set3, healthLayer1_Set3, healthLayer0_Set3, "Set 3");
        UpdateLayerSet(healthLayer3_Set4, healthLayer2_Set4, healthLayer1_Set4, healthLayer0_Set4, "Set 4");
    }

    void UpdateLayerSet(GameObject layer3, GameObject layer2, GameObject layer1, GameObject layer0, string setName)
    {
        if (layer3 != null) layer3.SetActive(false);
        if (layer2 != null) layer2.SetActive(false);
        if (layer1 != null) layer1.SetActive(false);
        if (layer0 != null) layer0.SetActive(false);

        switch (currentHealth)
        {
            case 3:
                if (layer3 != null) layer3.SetActive(true);
                Debug.Log($"Menampilkan layer ({setName}): 3 nyawa");
                break;
            case 2:
                if (layer2 != null) layer2.SetActive(true);
                Debug.Log($"Menampilkan layer ({setName}): 2 nyawa");
                break;
            case 1:
                if (layer1 != null) layer1.SetActive(true);
                Debug.Log($"Menampilkan layer ({setName}): 1 nyawa");
                break;
            case 0:
                if (layer0 != null) layer0.SetActive(true);
                Debug.Log($"Menampilkan layer ({setName}): 0 nyawa (Game Over)");
                break;
            default:
                Debug.LogWarning($"CurrentHealth tidak valid: {currentHealth}");
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }
    }
    public void RestartGame()
    {
        // Reload scene saat ini
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();

        // Jika di editor, log untuk memastikan dipanggil
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
