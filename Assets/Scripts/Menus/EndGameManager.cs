using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Store the scene path for runtime use.
    [SerializeField] private string finishScenePath;

    [SerializeField] private string menuScenePath;

    [SerializeField] public static bool isFinshed;

#if UNITY_EDITOR
    [SerializeField] private UnityEditor.SceneAsset finishScene;

    [SerializeField] private UnityEditor.SceneAsset menuScene;

    private void OnValidate()
    {
        if (finishScene != null)
        {
            finishScenePath = UnityEditor.AssetDatabase.GetAssetPath(finishScene);
        }
        if (menuScene != null)
        {
            menuScenePath = UnityEditor.AssetDatabase.GetAssetPath(menuScene);
        }
    }
#endif

    [SerializeField] private int waitTime = 20;

    void Update()
    {
        if (PlayerPrefs.GetString("FINISHED") == "true") {
            if (SceneManager.GetActiveScene().name == "Credits")
            {
                StartCoroutine(WaitForCredits(waitTime, finishScenePath));
            }
        }
        else {
            if (SceneManager.GetActiveScene().name == "Credits")
            {
                StartCoroutine(WaitForCredits(waitTime, menuScenePath));
            }
        }
    }

    private IEnumerator WaitForCredits(int seconds, string gotoScenePath)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(gotoScenePath);
    }
}
