#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Portal : MonoBehaviour
{
    // This will store the scene name for runtime use.
    [SerializeField] private string sceneName;

#if UNITY_EDITOR
    [SerializeField] private SceneAsset sceneAsset;

    // This method will be called whenever the script is changed in the editor.
    private void OnValidate()
    {
        // If a scene is assigned, update the sceneName.
        if (sceneAsset != null)
        {
            sceneName = sceneAsset.name;  // Get the name, not the path
        }
    }
#endif

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with the portal
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the scene
            LoadScene();
        }
    }

    // Use this method to load the scene during runtime
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the scene by its name
            if (sceneName != "Credits")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            else if (sceneName == "Credits")
            {
                PlayerPrefs.SetString("FINISHED", "true");
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }
}
