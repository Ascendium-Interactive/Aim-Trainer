using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameModeManager.Instance.SetGameMode(new TimedMode());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //GameModeManager.Instance.SetGameMode("MovingTargets");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //GameModeManager.Instance.SetGameMode("AmountBased");
        }
    }
}
