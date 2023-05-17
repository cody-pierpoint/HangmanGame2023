using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HangManScript : MonoBehaviour
{
    public int correctLetters;
    public int incorrectLetters;
    public bool gameOver;
    public string[] wordsToGuess;
    public string chosenWord;
    public int letterIndex;
    public bool foundLetter;
    //public int wordIndex;
    public TextMeshProUGUI[] letterDisplay;
    public TextMeshProUGUI[] guessedLetters;
    public TextMeshProUGUI[] incorrectLetterDisplay;
    public GameObject[] hangmanDrawing;
    public List<char> guessedCharacters = new List<char>(capacity: 26);

    // Start is called before the first frame update
    void Start()
    {
        guessedCharacters.Clear();
        for (int i = 0; i < hangmanDrawing.Length; i++)
        {
            hangmanDrawing[i].SetActive(false);

        }
        int randomWord = Random.Range(0, wordsToGuess.Length);
        chosenWord = wordsToGuess[randomWord].ToUpper();
        for (int i = 0; i < chosenWord.Length; i++)
        {
            letterDisplay[i].gameObject.SetActive(true);
            guessedLetters[i].gameObject.SetActive(true);
            guessedLetters[i].text = "";


        }
        correctLetters = chosenWord.Length;
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

    // and handling GUI events
    void OnGUI()
    {
        GuessWord();
    }

    //void correctLetter()
    //if(foundLetter)
    // 
    public void GuessWord()
    {
        //assign event.current to variable
        Event e = Event.current;
        //loop through word and check each letter in chosenword against the current keycode pressed
        if (e.type == EventType.KeyDown)
        {
            //create temp char to hold character and set 
            char inputCharacter = char.ToUpper(e.character);
            if (inputCharacter >= 'A' && inputCharacter <= 'Z')
            {
                //if inputcharacter List does not contain guessedcharacter
                if (!guessedCharacters.Contains(inputCharacter))
                {
                    guessedCharacters.Add(inputCharacter);
                    // add guessed character to list.
                    //list.add(inputcharacter);
                    //if correct letters != 0 and incorrect guesses != 10
                    for (int i = 0; i < chosenWord.Length; i++)
                    {
                        if (inputCharacter == chosenWord[i])
                        {
                            foundLetter = true;

                            Debug.Log(foundLetter + "if == chosenword" + inputCharacter);
                            //bool = true
                            letterDisplay[i].text = inputCharacter.ToString().ToUpper();
                            //if()
                            correctLetters--;

                            //if letter guessed correctly, display letter inputed
                            //minus 1 to corrected guesses;


                        }

                        //true   
                    }
                    if (inputCharacter != chosenWord[letterIndex])
                    {
                        Debug.Log(foundLetter + "if != chosenword");

                        foundLetter = false;

                        incorrectLetterDisplay[letterIndex].text = inputCharacter.ToString().ToUpper();
                        letterIndex++;

                        incorrectLetters--;

                        //if()
                    }
                    //if (!foundLetter)
                    //{

                    //}
                }
            }
            //else add one to incorrect guesses
            //    display letter inputed into incorrect guesses display.
            //if (Input.GetKey(e.keyCode))
            //{
            //    Debug.Log(e);
            //}
        }
        //Event guessInput = Event.current.character;
        ////assign event.current.character to variable
        ////char guessedInput = (char)Event.current.keyCode;
        ////guessedInput.ToString().ToUpper();
        ////Debug.Log(guessedInput);
        //if (Input.GetKey(Event.current.keyCode))
        //{
    }




    //if (correctLetters <= ChosenWord.Length)
    //{
    //    if (Event.current.keyCode == (char)ChosenWord.Length)
    //    {

    //    }
    //    Debug.Log("all letters not guessed" + correctLetters);
    //    for (int i = 0; i < ChosenWord.Length; i++)
    //    {
    //        if (guessedInput == ChosenWord[i])
    //        {
    //            guessedLetters[i].text = guessedInput.ToString();

    //        }
    //    }
    //}
}

