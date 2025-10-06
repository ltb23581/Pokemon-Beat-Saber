using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    public ScoreBar scoreBar;   

    void Awake()
    {
        scoreBar.UpdateBar(score);
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if (scoreBar != null)
            scoreBar.UpdateBar(score);
    }
}
