using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private CollectCoin collectCoin;

    private void Awake()
    {
        collectCoin = GetComponent<CollectCoin>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            collectCoin.score += 1;
            scoreText.text = "Score: " + collectCoin.score.ToString();
            Destroy(collision.transform.parent.gameObject);  
        }
    }
}
