using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    public float speed = 0.5f;

    private TextMeshProUGUI textComponent;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (textComponent == null) return;

        float hue = (Time.unscaledTime * speed) % 1f;
        textComponent.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}
