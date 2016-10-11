using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	public Text guessText;
	public Text guessLeft;
	private int guess;
	private int min;
	private int max;
	private int maxGuessesAllowed;

	// Use this for initialization
	void Start () {
		min = 1;
		max = 1000;
		guess = Random.Range (min, max + 1);;
		maxGuessesAllowed = 10;
		guessText.text = "" + guess;
		guessLeft.text = "Guesses Left\n" + maxGuessesAllowed;
	}
	
	public void GuessHigher(){
		min = guess;
		NextGuess ();
	}

	public void GuessLower(){
		max = guess;
		NextGuess ();
	}
	
	void NextGuess(){
		guess = Random.Range (min, max + 1);
		guessText.text = "" + guess;
		maxGuessesAllowed -= 1;
		guessLeft.text = "Guesses Left\n" + maxGuessesAllowed;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}
	}
}
