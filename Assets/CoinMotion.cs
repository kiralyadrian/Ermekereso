using UnityEngine;

public class CoinMotion : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 180f; // fok/másodperc
    [SerializeField] private float bobHeight = 0.25f;    // fel-le mozgás távolsága
    [SerializeField] private float bobSpeed = 3f;        // mozgás sebessége
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);

        float offset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.localPosition = startPosition + Vector3.up * offset;
    }
}
