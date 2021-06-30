using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public void onClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
