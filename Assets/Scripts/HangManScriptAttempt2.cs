using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class HangManScriptAttempt2 : MonoBehaviour
{
    //public struct HangSetUP
    //{
    //    public int letterIndex;
    //    public TextMeshProUGUI[] textDisplay;
    //}

    //public HangSetUP baseSetup;

    public bool letterFound = false;
    public string[] wordList;
    public string chosenWord;
    public int correctLetters;
    public int incorrectLetters;
    public int incorrectLetterIndex;
    public int correctLetterIndex;
    public TextMeshProUGUI[] baseDisplay;
    public TextMeshProUGUI[] guessedLetters;
    public TextMeshProUGUI[] incorrectLetterDisplay;
    public GameObject[] hangManDrawing;
    public List<char> guessedCharacters = new List<char>(capacity: 26);
    public bool gameOver;
    private Event inputEvent;
    public char inputCharacter;
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameSetup()
    {
        guessedCharacters.Clear();
        for (int i = 0; i < hangManDrawing.Length; i++)
        {
            hangManDrawing[i].SetActive(false);

        }
        int randomWord = Random.Range(0, wordList.Length);
        chosenWord = wordList[randomWord].ToUpper();
        for (int i = 0; i < chosenWord.Length; i++)
        {
            baseDisplay[i].gameObject.SetActive(true);
            guessedLetters[i].gameObject.SetActive(true);
            guessedLetters[i].text = "";


        }
        correctLetters = chosenWord.Length;
    }

    public void OnGUI()
    {
        if (!gameOver)
        {
            MakeGuess();

        }
    }

    public void CorrectGuess()
    {
        letterFound = false;
        for (int i = 0; i < chosenWord.Length; i++)
        {
            if (inputCharacter == chosenWord[i])
            {
                letterFound = true;
                if (letterFound)
                {
                    correctLetterIndex = i;
                    guessedLetters[correctLetterIndex].text = inputCharacter.ToString().ToUpper();
                    correctLetters--;
                }

            }
            
            //else
            //{
                
            //    letterFound = false;
            //    Debug.LogWarning("CorrectGuess Lettfound set to false");
            //}
        }


        

    }
    public void WinGame()
    {
        if (correctLetters == 0)
        {
            gameOver = true;

        }
    }
    public void LoseGame()
    {
        if (incorrectLetters == 0)
        {
            gameOver = true;
        }
    }
    public void GameOver()
    {
        if()
    }

    public void IncorrectGuess()
    {
        for (int i = 0; i < chosenWord.Length; i++)
        {
            Debug.Log("incorrectGuess For loop");

            if (inputCharacter != chosenWord[i])
            {
                letterFound = false;

            }
            if (!letterFound)
            {
                incorrectLetterDisplay[incorrectLetterIndex].text = inputCharacter.ToString().ToUpper();
            }
        }
        


    }

    public void DrawHangMan()
    {
        for (int i = 0; i < hangManDrawing.Length; i++)
        {
            if (!letterFound)
            {
                hangManDrawing[incorrectLetterIndex].SetActive(true);
            }
        }
    }

    public void MakeGuess()
    {

        inputEvent = Event.current;


        Debug.Log("eventType.keydown");
        //
        inputCharacter = char.ToUpper(inputEvent.character);
        Debug.Log("input Character to upper");
        if (inputCharacter >= 'A' && inputCharacter <= 'Z')
        {
            if (!guessedCharacters.Contains(inputCharacter))
            {
                guessedCharacters.Add(inputCharacter);

                Debug.Log("add input to guessed character");

                CorrectGuess();
                if (!letterFound)
                {
                    Debug.LogWarning("Letter Always Found");
                    IncorrectGuess();
                    DrawHangMan();
                    incorrectLetterIndex++;

                }
            }

        }






    }
}
