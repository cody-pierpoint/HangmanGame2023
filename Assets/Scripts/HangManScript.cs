using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class HangManScript : MonoBehaviour
{
    public int correctLetters;
    public int incorrectLetters;
    public bool gameOver;
    public string[] wordsToGuess;
    public string ChosenWord;
    //public int wordIndex;
    public TextMeshProUGUI[] letterDisplay;
    public TextMeshProUGUI[] guessedLetters;
    public GameObject[] hangmanDrawing;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hangmanDrawing.Length; i++)
        {
            hangmanDrawing[i].SetActive(false);

        }
        ChosenWord = wordsToGuess[wordsToGuess.Length - 1];
        for (int i = 0;i < ChosenWord.Length;i++) 
        {
            letterDisplay[i].gameObject.SetActive(true);
            guessedLetters[i].gameObject.SetActive(true);
            guessedLetters[i].text = "";


        }
        
        //letterDisplay[letterDisplay.Length].text = "";
        //letterDisplay[letterDisplay.Length].gameObject.SetActive(false);
        //wordsToGuess[0] = "Apple";
        //wordsToGuess[1] = "cat";
        //wordsToGuess[2] = "Computer";
        //wordsToGuess[3] = "Design";
        //wordsToGuess[4] = "Moon";
        //wordsToGuess[5] = "Celestial";
        //wordIndex = Random.Range(0, wordsToGuess.Length);
        //ChosenWord = wordsToGuess[wordIndex];
        //if (letterDisplay.Length < ChosenWord.Length)
        //{

        //    //for (int i = 0; i < ChosenWord.Length; i++)
        //    //{
        //    //    letterDisplay[i].gameObject.SetActive(true);

        //    //}
        //}
        //letterDisplay[letterDisplay.Length] = GameObject.FindGameObjectWithTag("Underline");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GuessWord()
    {
        string guessedInpute = Event.current.keyCode.ToString();
        if(correctLetters <= ChosenWord.Length)
        {

        }
    }
}
