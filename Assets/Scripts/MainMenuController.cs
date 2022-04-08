using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Text _recordScore;
    
    void Start()
    {
        _recordScore.text = "Record score: " + PlayerPrefs.GetInt("RecordScore");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}
