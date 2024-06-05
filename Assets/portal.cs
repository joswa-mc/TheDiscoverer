using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    // The name of the scene to load
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the portal is the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
