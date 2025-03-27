using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }

    public IGameMode currentGameMode;

    public string gameModeName;

    public TargetManager targetManager; // Reference to the spawner

    private bool gameStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            InputHandle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentGameMode.EndMode();
        }
        if(currentGameMode != null) { currentGameMode.Update(); }

    }
    public void SetGameMode(IGameMode newMode)
    {
        if (currentGameMode != null)
        {
            currentGameMode.EndMode();
        }
        
        currentGameMode = newMode;
        gameModeName = currentGameMode.ToString();
        Debug.Log("Switched to " + gameModeName);
    }

    private void InputHandle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameModeManager.Instance.SetGameMode(new TimedMode());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameModeManager.Instance.SetGameMode(new NumberedMode());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameModeManager.Instance.SetGameMode(new MovingMode());
        }
        if (currentGameMode != null && Input.GetKeyDown(KeyCode.Alpha9))
        {
            currentGameMode.StartMode();
        }

       
    }


    public IGameMode GetCurrentGameMode() => currentGameMode;



    public void StartCurrentGameMode()
    {
        Debug.Log("Target Spawn");

    }
}
