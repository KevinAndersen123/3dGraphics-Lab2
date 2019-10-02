using UnityEngine;
using UnityEngine.SceneManagement;
//@Author Krystian Sarowski

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    //Restarts the current level.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Closes down the application.
    public void QuitGame()
    {
        Application.Quit();
    }

}
