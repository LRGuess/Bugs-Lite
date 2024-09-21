using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    [SerializeField] private SceneAsset finishScene;
    [SerializeField] private int waitTime = 20;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    // Update is called once per frame
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
        SceneManager.LoadScene(finishScene.name);
    }
}
