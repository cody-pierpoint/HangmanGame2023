using System.Collections.Generic;
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
    public int incorrectLetterIndex = 1;
    public int correctLetterIndex = 1;
    public TextMeshProUGUI[] baseDisplay;
    public TextMeshProUGUI[] guessedLetters;
    public TextMeshProUGUI[] incorrectLetterDisplay;
    public GameObject[] hangManDrawing;
    public List<char> guessedCharacters = new List<char>(capacity: 26);
    public bool gameOver;
    private Event inputEvent;
    public char inputCharacter;
    public GameObject winPanel;
    public GameObject losePanel;
    public bool gameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        //GameSetup();
        for (int i = 0; i < hangManDrawing.Length; i++)
        {
            hangManDrawing[i].SetActive(false);
            incorrectLetterDisplay[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameSetup()
    {
        gameStart = true;
        for (int i = 0; i < baseDisplay.Length; i++)
        {
            baseDisplay[i].gameObject.SetActive(false);
        }
        chosenWord = string.Empty;
        gameOver = false;
        guessedCharacters.Clear();
        for (int i = 0; i < hangManDrawing.Length; i++)
        {
            hangManDrawing[i].SetActive(false);
            incorrectLetterDisplay[i].text = "";
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
        incorrectLetterIndex = 0;
    }

    public void OnGUI()
    {
        if (!gameOver && gameStart)
        {
            MakeGuess();

        }
        if (gameOver)
        {
            for (int i = 0; i < chosenWord.Length; i++)
            {
                guessedLetters[i].text = "";

            }
            for (int i = 0; i < hangManDrawing.Length; i++)
            {
                incorrectLetterDisplay[i].text = "";
            }
        }
        if (gameStart)
        {
            GameOver();

        }

    }

    public void mainmenu()
    {
        //correctLetterIndex = 2;
        //incorrectLetterIndex = 2;
        gameOver = false;
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        for (int i = 0; i < hangManDrawing.Length; i++)
        {
            hangManDrawing[i].SetActive(false);
            incorrectLetterDisplay[i].text = "";
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
        winPanel.SetActive(true);

    }
    public void LoseGame()
    {
        losePanel.SetActive(true);

    }
    public void GameOver()
    {

        if (correctLetters == 0)
        {
            gameOver = true;
            winPanel.SetActive(true);
            //WinGame();
            gameStart = false;

        }
        if (incorrectLetterIndex == 10)
        {
            gameOver = true;
            losePanel.SetActive(true);
            //LoseGame();
            gameStart = false;
        }
        else
        {
            gameOver = false;
        }


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

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
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
