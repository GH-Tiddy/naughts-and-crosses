using UnityEngine;
using UnityEngine.UI;

public class Preferences : MonoBehaviour {

    public Dropdown players;
    public Dropdown difficulty;
    public Image image;
    public Image arrow;
    public Text text;

    public void Players() {
        PlayerPrefs.SetInt("Players", players.value);
        if (players.value == 0) {
            image.enabled = true;
            arrow.enabled = true;
            text.enabled = true;
            difficulty.enabled = true;
        } else {
            image.enabled = false;
            arrow.enabled = false;
            text.enabled = false;
            difficulty.enabled = false;
        }
    }

    public void Difficulty() {
        PlayerPrefs.SetInt("Difficulty", difficulty.value);
    }

}
