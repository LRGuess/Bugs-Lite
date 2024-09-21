using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class HotkeyManager : MonoBehaviour
{
    [SerializeField] private bool MenuHotkey = false;
    [SerializeField] private SceneAsset menuScene;
    [SerializeField] private bool Level1Hotkey = true;
    [SerializeField] private SceneAsset level1Scene;
    [SerializeField] private bool RestartHotkey = false;
    [SerializeField] private bool ExitGameHotkey = true;
    [SerializeField] private bool SettingsHotkey = true;
    [SerializeField] private MenuManager menuManager;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ExitGameHotkey)
        {
            // Open the menu
            Debug.Log("Quitting game");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.M) && MenuHotkey)
        {
            // Open the menu
            SceneManager.LoadScene(menuScene.name);
        }
        if ((Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Return)) && Level1Hotkey)
        {
            // Load level 1
            SceneManager.LoadScene(level1Scene.name);
        }
        if (Input.GetKeyDown(KeyCode.R) && RestartHotkey)
        {
            // Restart the current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.S) && SettingsHotkey)
        {
            // Open the settings
            menuManager.ToggleSettings();
        }
    }
}
