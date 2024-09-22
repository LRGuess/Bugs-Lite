using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Store the scene path for runtime use.
    [SerializeField] private string finishScenePath;

#if UNITY_EDITOR
    [SerializeField] private UnityEditor.SceneAsset finishScene;

    private void OnValidate()
    {
        if (finishScene != null)
        {
            finishScenePath = UnityEditor.AssetDatabase.GetAssetPath(finishScene);
        }
    }
#endif

    [SerializeField] private int waitTime = 20;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            StartCoroutine(WaitForCredits(waitTime));
        }
    }

    private IEnumerator WaitForCredits(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(finishScenePath);
    }
}
