using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Players", 0);
        PlayerPrefs.SetInt("Difficulty", 0);
	}
}
