using UnityEngine;

public class TextPulse : MonoBehaviour
{
    public float pulseSpeed = 3f;
    public float pulseAmount = 0.08f;

    private Vector3 originalScale;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float pulse = 1f + Mathf.Sin(Time.unscaledTime * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale * pulse;
    }
}
