using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BombAnimation1 : MonoBehaviour
{
    public GameObject imageObject;
    public GameObject copyImageObject;
    public Transform[] upperBoxes;
    public Transform[] lowerBoxes;
    public float moveSpeed = 5f;
    public float shrinkSpeed = 10f;

    public TextMeshProUGUI text;
    int upperRandom = 0, lowerRandom = 0;
    public Transform eliminatedMember;

    Renderer memberRenderer;
    private void Start()
    {
        RandomizeDestinations();
    }

    void Update()
    {
        Transform randomUpperBox = upperBoxes[upperRandom];
        MoveToBox(randomUpperBox.position, imageObject);
        Scale(imageObject);

        if (eliminatedMember != null && randomUpperBox == eliminatedMember)
        {
            RandomizeDestinations();
        }

        Transform randomLowerBox = lowerBoxes[lowerRandom];
        MoveToBox(randomLowerBox.position, copyImageObject);
        Scale(copyImageObject);

        if (eliminatedMember != null && randomLowerBox == eliminatedMember)
        {
            RandomizeDestinations();
        }

        disappear();
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
            text.text = "Növbəti raund Başlayır!";
            return;
        }

        Vector3 newScale = obj.transform.localScale - new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
        obj.transform.localScale = newScale;
    }

    void RandomizeDestinations()
    {
        upperRandom = Random.Range(0, upperBoxes.Length);
        lowerRandom = Random.Range(0, lowerBoxes.Length);
    }

    void disappear()
    {
        eliminatedMember.gameObject.SetActive(false);
    }
}
