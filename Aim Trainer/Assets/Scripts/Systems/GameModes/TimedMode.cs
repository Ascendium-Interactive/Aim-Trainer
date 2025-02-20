using UnityEngine;

public class TimedMode : IGameMode
{
    private float gameTime = 60f; // Total game duration
    private float countdownTime = 3f; // Pre-game countdown
    private bool isCountdownActive = false;
    private bool isGameActive = false;

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
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                EndMode();
            }
            else
            {
                Debug.Log($"Time Left: {Mathf.CeilToInt(gameTime)}");
            }
        }
    }

    public void StartMode() // Called when the mode begins.
    {
        Debug.Log("Timer Mode Started!");
        isCountdownActive = true;
        countdownTime = 3f;
        gameTime = 60f;
        //call GameModeManager.Instance.targetSpawner.StartSpawning() here, for example.
    }

    public void EndMode() // Handles cleanup/reset when the mode ends.
    {
        isGameActive = false;
        Debug.Log("Timer Mode Ended!");
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
