using UnityEngine;
using UnityEngine.UI;

public class puntaje : MonoBehaviour
{
    public static puntaje Instance;

    public int score = 0;
    public Text scoreText; // Referencia al UI Text en el Canvas

    void Awake()
    {
        // Asegurar que sea único
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}
