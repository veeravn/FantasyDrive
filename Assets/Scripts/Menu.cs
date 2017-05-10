using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MazeScene()
    {
        SceneManager.LoadScene("Maze");
    }
    public void FreeDriveScene()
    {
        SceneManager.LoadScene("FreeMode");
    }
	public void TimeLapseScene()
	{
		SceneManager.LoadScene("TimeDrive");
	}
    public void QuitButton()
    {
        Application.Quit();
    }
	public void MenuScene() {
		SceneManager.LoadScene("Menu 3D");
	}
	public void LeaderBoardScene() {
		SceneManager.LoadScene("LeaderBoard");
	}
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}