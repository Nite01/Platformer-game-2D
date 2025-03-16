using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void GameStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Start");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

}
