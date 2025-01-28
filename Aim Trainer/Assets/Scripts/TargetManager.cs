using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public BoxCollider spawnArea;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTarget();
        UpdateScoreText();
    }

    public void SpawnTarget()
    {
        Vector3 randomPosition = GetRandomPointInBounds(spawnArea.bounds);

        Quaternion uprightRotation = Quaternion.Euler(180, 0, 0);

        Instantiate(targetPrefab, randomPosition, uprightRotation);
    }

    public void OnTargetDestroyed()
    {
        score ++;
        UpdateScoreText();
        //Debug.Log("Score: " + score);
        SpawnTarget();
    }

    private Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
            );
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
