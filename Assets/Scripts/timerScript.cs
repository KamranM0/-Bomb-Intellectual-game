using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer_text;
    [SerializeField] float total_time = 45f;
    private float current_time;
    void Start()
    {
        current_time = total_time;
    }


    void Update()
    {
        if (current_time > 0)
        {
            current_time -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Timer has reached zero, you can handle the timer completion here
            PlayerPrefs.SetInt("numOfPlayers", 3);
            SceneManager.LoadScene("EliminatedScene");
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(current_time / 60);
        int seconds = Mathf.FloorToInt(current_time % 60);

        timer_text.text = string.Format("{0:00}:{1:00}",minutes, seconds);
    }
}
