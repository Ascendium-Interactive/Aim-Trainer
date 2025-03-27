
public interface IGameMode
{
    void StartMode(); // Called when the mode begins.
    void EndMode(); // Handles cleanup/reset when the mode ends.

    void Update();
}
