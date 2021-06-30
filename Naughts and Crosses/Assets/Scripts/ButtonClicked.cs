using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ButtonClicked : MonoBehaviour {

    public GameManager gameManager;
    public Image button;
    public int number;
    public SetText setText;
    public int counter = 0;

    public void OnClickEnter() {

        int[] arr = gameManager.getArr();
        if (arr[number] > 1) {

            setText.Set(number, gameManager.getMoves() % 2);

            if ((!gameManager.GameOver(arr) && gameManager.getMoves() < 9) && (PlayerPrefs.GetInt("Players") == 0)) {
                if (PlayerPrefs.GetInt("Difficulty") == 0) {
                    RandomAI();
                } else if (PlayerPrefs.GetInt("Difficulty") == 1) {
                    BetterAI();
                } else if (PlayerPrefs.GetInt("Difficulty") == 2) {
                    SmartAI();
                }
            }
        }
    }

    public void RandomAI() {

        int[] arr = gameManager.getArr();
        int choice;
        do {
            choice = UnityEngine.Random.Range(0, 9);
        } while (arr[choice] <= 1);
        setText.Set(choice, 1);
    }

    public void BetterAI() {

        int[] arr = gameManager.getArr();
        int choice = CheckTwo(arr);

        if (choice == 10) {
            do {
                choice = UnityEngine.Random.Range(0, 9);
            } while (arr[choice] <= 1);
        }

        setText.Set(choice, 1);

    }

    public void SmartAI() {

        int moves = gameManager.getMoves() + 1;
        int maxNumber = -2;
        int maxIndex = 0;

        for (int i = 0; i < 9; i++) {
            counter++;
            int[] tempArr = Copy(gameManager.getArr());
            if (tempArr[i] > 1) {
                tempArr[i] = 1;
                int number;
                if (gameManager.GameOver(tempArr)) {
                    if ((moves % 2) == 0) {
                        number = 1;
                    } else {
                        number = -1;
                    }
                } else if (moves == 9) {
                    number = 0;
                } else {
                    number = xTempGame(tempArr, moves + 1);
                }
                if (number > maxNumber) {
                    maxNumber = number;
                    maxIndex = i;
                }

            }
        }

        setText.Set(maxIndex, 1);

    }

    public int TempGame(int[] arr, int moves) {

        List<int> minimax = new List<int>(9 - moves);

        for (int i = 0; i < 9; i++) {
            counter++;
            int[] tempArr = Copy(arr);
            if (tempArr[i] > 1) {
                tempArr[i] = 1 - (moves % 2);
                if (gameManager.GameOver(tempArr)) {
                    if ((moves % 2) == 0) {
                        minimax.Add(1);
                    } else {
                        minimax.Add(-1);
                    }
                } else if (moves == 9) {
                    minimax.Add(0);
                } else {
                    minimax.Add(TempGame(Copy(tempArr), moves + 1));
                }
            }
        }

        if ((moves % 2) == 1) {
            return Min(minimax);
        } else {
            return Max(minimax);
        }
    }

    public int xTempGame(int[] arr, int moves) {

        List<int> minimax = new List<int>(9 - moves);

        for (int i = 0; i < 9; i++) {
            counter++;
            int[] tempArr = Copy(arr);
            if (tempArr[i] > 1) {
                tempArr[i] = 1 - (moves % 2);
                if (gameManager.GameOver(tempArr)) {
                    if ((moves % 2) == 0) {
                        if ((moves % 2) == 0) {
                            return 1;
                        } else {
                            minimax.Add(1);
                        }
                    }
                    else {
                        if ((moves % 2) == 1) {
                            return -1;
                        } else {
                            minimax.Add(-1);
                        }
                    }
                } else if (moves == 9){
                    minimax.Add(0);
                } else {
                    minimax.Add(xTempGame(Copy(tempArr), moves + 1));
                }
            }
        }

        if ((moves % 2) == 1) {
            return Min(minimax);
        } else {
            return Max(minimax);
        }
    }

    public void printArr(int[] arr) {
        String str = "";
        for (int i = 0; i < arr.Length; i++) {
            str += arr[i] + " ";
        }
    }

    public void printGoodArr(int[] arr) {
        String str = "";
        for (int i = 0; i < 3; i++) {
            str += arr[i] + " ";
        }
        str = "";
        for (int i = 3; i < 6; i++) {
            str += arr[i] + " ";
        }
        str = "";
        for (int i = 6; i < 9; i++){
            str += arr[i] + " ";
        }
    }

    public void printList(List<int> arr) {
        String str = "";
        for (int i = 0; i < arr.Count; i++) {
            str += arr[i] + " ";
        }
        Debug.Log(str);
    }

    public int Min(List<int> arr) {

        int minValue = arr[0];

        for (int i = 1; i < arr.Count;  i++) {
            if (arr[i] < minValue) {
                minValue = arr[i];
            }
        }

        return minValue;
    }

    public int Max(List<int> arr) {

        int maxValue = arr[0];

        for (int i = 1; i < arr.Count; i++) {
            if (arr[i] > maxValue) {
                maxValue = arr[i];
            }
        }

        return maxValue;
    }

    public int[] Copy(int[] arr) {
        int[] newArr = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) {
            newArr[i] = arr[i];
        }
        return newArr;
    }

    public static int TwoEqual(int a, int b, int c) {
        if (((a == 1) && (a == b) && (c > 1)) || ((a == 1) && (a == c) && (b > 1)) || ((b == 1) && (b == c) && (a > 1))) {
            return 1;
        } else if (((a == 0) && (a == b) && (c > 1)) || ((a == 0) && (a == c) && (b > 1)) || ((b == 0) && (b == c) && (a > 1))) {
            return 0;
        } else {
            return 2;
        }
    }

    public static int ChooseInt(int a, int b, int c) {
        if (a > 1) {
            return a - 2;
        } else if (b > 1){
            return b - 2;
        } else {
            return c - 2;
        }
    }

    public int CheckTwo(int[] arr) {
        if (TwoEqual(arr[0], arr[1], arr[2]) <= 1) {
            return ChooseInt(arr[0], arr[1], arr[2]);
        } else if (TwoEqual(arr[3], arr[4], arr[5]) <= 1) {
            return ChooseInt(arr[3], arr[4], arr[5]);
        } else if (TwoEqual(arr[6], arr[7], arr[8]) <= 1) {
            return ChooseInt(arr[6], arr[7], arr[8]);
        } else if (TwoEqual(arr[0], arr[3], arr[6]) <= 1) {
            return ChooseInt(arr[0], arr[3], arr[6]);
        } else if (TwoEqual(arr[1], arr[4], arr[7]) <= 1) {
            return ChooseInt(arr[1], arr[4], arr[7]);
        } else if (TwoEqual(arr[2], arr[5], arr[8]) <= 1) {
            return ChooseInt(arr[2], arr[5], arr[8]);
        } else if (TwoEqual(arr[0], arr[4], arr[8]) <= 1) {
            return ChooseInt(arr[0], arr[4], arr[8]);
        } else if (TwoEqual(arr[2], arr[4], arr[6]) <= 1) {
            return ChooseInt(arr[2], arr[4], arr[6]);
        } else {
            return 10;
        }
    }
}