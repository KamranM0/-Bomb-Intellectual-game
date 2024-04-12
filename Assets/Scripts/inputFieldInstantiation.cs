using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inputFieldInstantiation : MonoBehaviour
{
 
    public TMP_InputField inputFieldPrefab;
    public Transform panelTransform;
    private TMP_InputField[] inputFields;
    private int currentIndex = 0;
    public int numberOfBoxes;

    public TextAsset questionsAndAnswersFile;
    public TextMeshProUGUI questionDisplayed;
    private string answer;


    void Start()
    {
        if (questionsAndAnswersFile != null)
        {
            LoadRandomQuestionAndAnswer();
            Debug.Log(answer );
        }
        else
        {
            Debug.LogError("Questions and Answers file is not assigned!");
        }

        answer = answer.Substring(0, answer.Length-1);

        numberOfBoxes = answer.Length ;
        Debug.Log($"number of boxes= {numberOfBoxes} and answer = {answer} and asnwer.length = {answer.Length}" );
        CreateInputFields(numberOfBoxes);
        FocusOnInputField(currentIndex);
        //Debug.Log(answer);


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
                int randomIndex = UnityEngine.Random.Range(0, allLines.Length-1);

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


    void CreateInputFields(int count)
    {
        inputFields = new TMP_InputField[count];

        for (int i = 0; i < count; i++)
        {
            TMP_InputField newInputField = Instantiate(inputFieldPrefab, panelTransform);
            newInputField.characterLimit = 1;
            inputFields[i] = newInputField;

            // Attach a click event handler to the input field
            AddClickEvent(newInputField, i);
        }
    }

    void AddClickEvent(TMP_InputField inputField, int index)
    {
        EventTrigger trigger = inputField.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = inputField.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
        entry.callback.AddListener((data) => { OnInputFieldClick(index); });
        trigger.triggers.Add(entry);
    }

    void OnInputFieldClick(int index)
    {
        currentIndex = index;
        FocusOnInputField(currentIndex);
    }

    void Update()
    {
        CheckInput();
       

    }

    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string key = Input.inputString;

            if (!string.IsNullOrEmpty(key) && key.Length == 1)
            {
                InputCharacter(key);
                MoveToNextBox();
                
            }
        }
    }

    void InputCharacter(string character)
    {
        if (currentIndex < inputFields.Length)
        {
            inputFields[currentIndex].text = character.ToUpper();
            
            
        }
    }

    void MoveToNextBox()
    {
        if (currentIndex < inputFields.Length - 1)
        {
            currentIndex++;
            FocusOnInputField(currentIndex);
        }
    }

    void FocusOnInputField(int index)
    {
        inputFields[index].ActivateInputField();
    }

    string GetInputString()
    {
        string inputEntered = "";
        for(int i = 0; i < inputFields.Length; i++)
        {
            inputEntered = inputEntered + inputFields[i].text;
        }
        return inputEntered;
    }

    public void checkAnswer()
    {
        

        if (GetInputString() == answer)
        {
            PlayerPrefs.SetInt("numOfPlayers", 4);
            PlayerPrefs.Save();
            SceneManager.LoadScene("InternalGame");
            return;
        }
        else
        {
            
            PlayerPrefs.SetInt("numOfPlayers", 3);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EliminatedScene");
            
            return;
        };


    }


}