using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private SceneAsset sceneAsset;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneAsset.name);
        }
    }
}
