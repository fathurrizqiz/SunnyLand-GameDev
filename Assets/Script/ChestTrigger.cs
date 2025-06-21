using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public Sprite openSprite;        // Sprite terbuka
    public GameObject pointObject;   // Objek point (misalnya koin)

    private SpriteRenderer spriteRenderer;
    private bool isOpened = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (pointObject != null)
        {
            pointObject.SetActive(false);  // pastikan tidak aktif saat mulai
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpened && other.CompareTag("Player"))
        {
            spriteRenderer.sprite = openSprite;
            isOpened = true;

            if (pointObject != null)
            {
                pointObject.SetActive(true);  // munculkan point!
            }
        }
    }
}
