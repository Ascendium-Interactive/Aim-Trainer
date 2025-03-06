using UnityEngine;

public class NumberedMode : IGameMode
{
    private float gameTime = 60f; // Total game duration
    private float countdownTime = 3f; // Pre-game countdown
    private bool isCountdownActive = false;
    private bool isGameActive = false;
    private int targetLimit = 20;
    public void Update()
    {
        if (isCountdownActive)
        {
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0)
            {
                StartGame();
            }
            else
            {
                Debug.Log($"Countdown: {Mathf.CeilToInt(countdownTime)}");
            }
        }
        else if (isGameActive)
        {
            gameTime += Time.deltaTime;
            //Debug.Log($"Time Left: {Mathf.CeilToInt(gameTime)}");
        }
        if (GameModeManager.Instance.targetManager.scoreCount == targetLimit && isGameActive)
        {
            EndMode();
        }
    }

    public void StartMode() // Called when the mode begins.
    {
        Debug.Log("Numbered Mode Started!");
        isCountdownActive = true;
        countdownTime = 3f;
        gameTime = 0f;
        //call GameModeManager.Instance.targetSpawner.StartSpawning() here, for example.
    }

    public void EndMode() // Handles cleanup/reset when the mode ends.
    {
        isGameActive = false;
        Debug.Log("Numbered Mode Ended!");
        GameModeManager.Instance.targetManager.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        Debug.Log("GO! Game Started!");
        isCountdownActive = false;
        isGameActive = true;
        GameModeManager.Instance.targetManager.gameObject.SetActive(true);
    }
}
