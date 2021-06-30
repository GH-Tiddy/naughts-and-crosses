using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    public Text[] text;

    public GameManager gameManager;

    public void Set(int choice, int type) {

        gameManager.setMoves(gameManager.getMoves() + 1);

        if (type == 0) {
            text[choice].text = "O";
        } else {
            text[choice].text = "X";
        }

        int[] arr = gameManager.getArr();
        arr[choice] = type;
        gameManager.setArr(arr);

        gameManager.CheckEnd();
    }
}
