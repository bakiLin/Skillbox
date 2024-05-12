using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [HideInInspector] public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            SetNewScore();
            Destroy(collision.gameObject);
        }
    }

    private void SetNewScore()
    {
        score += 1;
        string text = "Score: " + score.ToString();
        scoreText.text = text;
    }
}
