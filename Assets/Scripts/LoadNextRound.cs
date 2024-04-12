using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextRound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndSwitch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator WaitAndSwitch()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("QuestionScene");
    }
}
