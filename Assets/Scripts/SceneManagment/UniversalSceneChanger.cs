using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UniversalSceneChanger : MonoBehaviour
{
    // This stores the scene name for runtime use.
    [SerializeField] private string sceneToLoadName;

#if UNITY_EDITOR
    [SerializeField] private UnityEditor.SceneAsset sceneToLoad;

    private void OnValidate()
    {
        if (sceneToLoad != null)
        {
            sceneToLoadName = sceneToLoad.name;  // Get the scene's name
        }
    }
#endif

    [SerializeField] private bool isTimed;
    [SerializeField] private int secondsToWait;
    [SerializeField] private bool isSlider;
    [SerializeField] private Slider loaderSlider;
    [SerializeField] private float changeValue;

    // Start is called before the first frame update
    void Start()
    {
        if (isTimed)
        {
            StartCoroutine(WaitSeconds(secondsToWait));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlider && loaderSlider != null)
        {
            if (loaderSlider.value == changeValue)
                SceneManager.LoadScene(sceneToLoadName);
        }
    }

    private IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneToLoadName);
    }

    public void ImmediateChange(string sceneName)
    {
        PlayerPrefs.SetString("FINISHED", "false");
        SceneManager.LoadScene(sceneName);
    }

    public void ExitNow()
    {
        Application.Quit();
    }
}
