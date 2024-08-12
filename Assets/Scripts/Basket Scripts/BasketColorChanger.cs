using UnityEngine;

public class BasketColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] colors;

    [SerializeField] private float colorChangingInterval = 2f;

    private SpriteRenderer[] SpriteRenderers;

    public Color CurrentColor { get; private set; }

    private void Start()
    {
        SpriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        InvokeRepeating("ChangeColor", 0f, colorChangingInterval);
    }

    private void ChangeColor()
    {
        Color newColor = GetRandomColor();

        CurrentColor = newColor;

        foreach (SpriteRenderer spriteRenderer in SpriteRenderers)
        {
            if (spriteRenderer != null)
            {
                // Устанавливаем цвет для спрайта
                spriteRenderer.color = newColor;
            }
        }
    }

    public Color GetRandomColor()
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];

        return randomColor;
    }
}
