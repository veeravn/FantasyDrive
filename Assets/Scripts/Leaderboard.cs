using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {
	public Text[] highscores;

	int [] highscorevalues;
	// Use this for initialization
	void Start () {
		highscorevalues = new int[highscores.Length];	
		for(int x=0; x<highscores.Length; x++) {
			highscorevalues [x] = PlayerPrefs.GetInt ("highscorevalues" + x);
		}
		DrawScores ();
	}
	void SaveScores(){
		for(int x=0; x<highscores.Length; x++) {
			 PlayerPrefs.SetInt ("highscorevalues" + x,highscorevalues[x]);
		}
	}
	void DrawScores(){
		for(int x=0; x<highscores.Length; x++) {
			highscores[x].text =highscorevalues[x].ToString();
		}
	}

	public void CheckForHighScores(int _value){
	
		for (int x = 0; x < highscores.Length; x++) {
			if (_value > highscorevalues [x]) {
				for (int y = highscores.Length - 1; y > x; y--) {
					highscorevalues [y] = highscorevalues [y - 1];
				}
				highscorevalues [x] = _value;
				DrawScores ();
				SaveScores ();
				break;
			}
	
		}
	}
	// Update is called once per frame
	void Update () {
			
	}
}
