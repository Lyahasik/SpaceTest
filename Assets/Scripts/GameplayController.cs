using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    private static bool _isPlaying;

    public static bool IsPlaying => _isPlaying;
    
    void OnEnable()
    {
        _isPlaying = true;
        
        GameEventManager.OnGameOver += GameOver;
    }

    void GameOver()
    {
        _isPlaying = false;
    }
    
    public void MainMenu()
    {
        GameEventManager.Clear();
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        GameEventManager.Clear();
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
}
