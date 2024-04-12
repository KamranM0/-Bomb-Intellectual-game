
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerLaunch : MonoBehaviour
{
    public UnityEngine.UI.Image imagePrefab;
    public Transform panelTransform1;
    public Transform panelTransform2;
    private UnityEngine.UI.Image[] images;
    public int countx;

    void Start()
    {
        countx = PlayerPrefs.GetInt("numOfPlayers");   
        CreateInputFields(countx,panelTransform1);
        CreateInputFields(4,panelTransform2);
    }

    
    

    void CreateInputFields(int count, Transform panelTransform)
    {
        images = new UnityEngine.UI.Image[count];

        for (int i = 0; i < count; i++)
        {
            UnityEngine.UI.Image newInputField = Instantiate(imagePrefab, panelTransform);
            images[i] = newInputField;
        }
    }
}
