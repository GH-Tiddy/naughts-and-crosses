using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour {

    public Text win;

    public void Start() {
        int theWinner = GameManager.winner;
        if (theWinner == 0) {
            win.text = "Crosses Win!";
        }
        else if (theWinner == 1) {
            win.text = "Naughts Win!";
        }
        else {
            win.text = "Draw!";
        }

    }
}
