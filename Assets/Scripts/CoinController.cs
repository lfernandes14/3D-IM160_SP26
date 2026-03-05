using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioSource collectSound;
    private int coinCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCount = 0;   
        coinText.text = "Coins: " + coinCount.ToString();
    }

    /// <summary>
    /// Increases the coint total and destroys the coin aka it has been collected
    /// </summary>
    /// <param name="triggerObject"></param>
    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("CoinTag"))
        {
            coinCount++;
            collectSound.Play();
            coinText.text = "Coins: " + coinCount.ToString();
            Destroy(triggerObject.gameObject);
        }
    }
}
