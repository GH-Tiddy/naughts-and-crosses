using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int moves;
    public int[] arr;
    public bool gameOver = false;
    public static int winner;

    public int getMoves() {
        return moves;
    }

    public void setMoves(int moves){
        this.moves = moves;
    }

    public int[] getArr() {
        return arr;
    }

    public void setArr(int[] arr) {
        this.arr = arr;
    }

    public int getWinner() {
        return winner;
    }

    public void CheckEnd() {

        gameOver = GameOver(arr);
        if (gameOver) {
            if ((moves % 2) == 0) {
                winner = 0;
            } else {
                winner = 1;
            }
            Invoke("LoadScene", 0.7f);

        } else if (moves == 9) {
            winner = 2;
            Invoke("LoadScene", 0.7f);
        }
    }

    void LoadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static bool isEqual(int a, int b, int c) {
        return ((a == b) && (b == c));
    }

    public bool GameOver(int[] arr) {
        return ((isEqual(arr[0], arr[1], arr[2])) || (isEqual(arr[3], arr[4], arr[5])) || (isEqual(arr[6], arr[7], arr[8])) || (isEqual(arr[0], arr[3], arr[6])) || (isEqual(arr[1], arr[4], arr[7])) || (isEqual(arr[2], arr[5], arr[8])) || (isEqual(arr[0], arr[4], arr[8])) || (isEqual(arr[2], arr[4], arr[6])));
    }

}
