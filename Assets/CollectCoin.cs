using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioClip coinSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }
            CoinCounter.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}