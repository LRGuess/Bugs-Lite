using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    public bool isCheckpoint;
    public string currentLevel;

    void Start() {
        currentLevel = SceneManager.GetActiveScene().name;
        if (isCheckpoint) {
            PlayerPrefs.SetString("CHECKPOINT", currentLevel);
        }
    }
}
