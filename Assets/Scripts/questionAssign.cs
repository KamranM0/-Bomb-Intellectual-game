using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class questionAssign : MonoBehaviour
{
    public TextAsset questionsAndAnswersFile;
    public TextMeshProUGUI questionDisplayed;
    public string answer;

    void Start()
    {
        if (questionsAndAnswersFile != null)
        {
            LoadRandomQuestionAndAnswer();
            Debug.Log(answer + "**********");
        }
        else
        {
            Debug.LogError("Questions and Answers file is not assigned!");
        }
    }

    void LoadRandomQuestionAndAnswer()
    {
        try
        {
            // Split the text asset into lines
            string[] allLines = questionsAndAnswersFile.text.Split('\n');

            if (allLines.Length > 0)
            {
                // Pick a random index
                int randomIndex = UnityEngine.Random.Range(0, allLines.Length);

                // Get the question and answer at the random index
                string randomLine = allLines[randomIndex];
                string[] parts = randomLine.Split('|');

                if (parts.Length == 2)
                {
                    string question = parts[0];
                    answer = parts[1];

                    // Print the random question and answer
                    questionDisplayed.text = question;
                }
                else
                {
                    Debug.LogWarning("Invalid line format: " + randomLine);
                }
            }
            else
            {
                Debug.LogWarning("The file is empty");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error reading the file: " + e.Message);
        }
    }
}


