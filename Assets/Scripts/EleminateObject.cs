using UnityEngine;

public class EleminateObject : MonoBehaviour
{
    public float destroyDelay = 2f; // Adjust this value to set the delay before destroying the object

    public GameObject obj;

    void Start()
    {
        // Check if the GameObject has a Renderer component
        Renderer objRenderer = obj.GetComponent<Renderer>();

        if (objRenderer != null)
        {
            // Change the color of the obj GameObject to red
            objRenderer.material.color = Color.red;

            // Invoke the DestroyObject method after a specified delay
            Invoke("DestroyObject", destroyDelay);
        }
        else
        {
            Debug.LogError("Renderer component not found on the obj GameObject");
        }
    }

    void DestroyObject()
    {
        // Deactivate the obj GameObject
        obj.SetActive(false);
    }
}
