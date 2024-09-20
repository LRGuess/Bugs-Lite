using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UniversalSceneChanger : MonoBehaviour
{

    [SerializeField] private SceneAsset sceneToLoad;
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
                SceneManager.LoadScene(sceneToLoad.name);
        }
    }
    
    private IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneToLoad.name);
    }

    public void ImmidateChange(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    public void ExitNow()
    {
        Application.Quit();
    }
}
