using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSprite : MonoBehaviour
{
    public GameObject bomb;
    void Start()
    {
        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        bomb.transform.position = screenCenter;
    }
}