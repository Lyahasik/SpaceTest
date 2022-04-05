using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    private static bool _isPlaying;

    public static bool IsPlaying => _isPlaying;
    
    void OnEnable()
    {
        _isPlaying = true;
        
        GameEventManager.OnKillPlayer += PlayerKill;
        GameEventManager.OnGameOver += GameOver;
    }
    
    void Update()
    {
        if (_isPlaying)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameEventManager.SendChangeHealth(-37);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                GameEventManager.SendChangeHealth(50);
            }
            if (Input.GetButtonDown("Fire3"))
            {
                GameEventManager.SendChangeScore(10);
            }
        }
    }

    void PlayerKill()
    {
        GameEventManager.SendChangeHealth(100);
        GameEventManager.SendChangeLives(-1);
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
