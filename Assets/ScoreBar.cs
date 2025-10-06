using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    public Transform fill;       
    public int maxScore = 2100;  // score needed to fill bar

    
    public void UpdateBar(int score)
    {
        float t = Mathf.Clamp01((float)score / maxScore);
        Debug.Log($"Updating bar: score={score}, t={t}");
        fill.localScale = new Vector3(t, fill.localScale.y, fill.localScale.z);
        fill.localPosition = new Vector3((t - 5f) * 0.5f, fill.localPosition.y, fill.localPosition.z);
    }
}
