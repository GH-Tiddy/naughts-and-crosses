using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public void Restart() {
        SceneManager.LoadScene(2);
    }

    public void MainMenu() {
        PlayerPrefs.SetInt("Players", 0);
        PlayerPrefs.SetInt("Difficulty", 0);
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }
}
