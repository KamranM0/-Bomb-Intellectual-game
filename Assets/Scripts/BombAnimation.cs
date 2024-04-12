using TMPro;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{
    public GameObject imageObject;
    public GameObject copyImageObject;
    public Transform[] upperBoxes;
    public Transform[] lowerBoxes;
    public float moveSpeed = 5f;
    public float shrinkSpeed = 1f;

    public TextMeshProUGUI text;
    public TextMeshProUGUI nextText;
    int upperRandom = 0, lowerRandom = 0;
    private void Start()
    {
        upperRandom = Random.Range(0, upperBoxes.Length);
        lowerRandom = Random.Range(0, lowerBoxes.Length);

    }
    void Update()
    {

        Transform randomUpperBox = upperBoxes[upperRandom];

        MoveToBox(randomUpperBox.position, imageObject);
        Scale(imageObject);

        Transform randomLowerBox = lowerBoxes[lowerRandom];
        MoveToBox(randomLowerBox.position, copyImageObject);
        Scale(copyImageObject);

    }

    void MoveToBox(Vector3 targetPosition, GameObject obj)
    {

        Vector3 newPosition = Vector3.Lerp(obj.transform.position, targetPosition, Time.deltaTime * moveSpeed);
        obj.transform.position = newPosition;

    }

    void Scale(GameObject obj)
    {
        if (obj.transform.localScale.x < 1.9f)
        {
            text.text = "Oyun başladı!";
            return;
        }

        Vector3 newScale = obj.transform.localScale - new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
        obj.transform.localScale = newScale;
    }
}