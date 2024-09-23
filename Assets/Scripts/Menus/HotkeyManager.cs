using UnityEngine;
using UnityEngine.SceneManagement;

public class HotkeyManager : MonoBehaviour
{
    [SerializeField] private bool MenuHotkey = false;
    [SerializeField] private string menuScenePath;

    [SerializeField] private bool Level1Hotkey = true;
    [SerializeField] private string level1ScenePath;

    [SerializeField] private bool RestartHotkey = false;
    [SerializeField] private bool ExitGameHotkey = true;
    [SerializeField] private bool SettingsHotkey = true;
    [SerializeField] private MenuManager menuManager;

    private PlayerManager player;

#if UNITY_EDITOR
    [SerializeField] private UnityEditor.SceneAsset menuScene;
    [SerializeField] private UnityEditor.SceneAsset level1Scene;
    

    private void OnValidate()
    {
        if (menuScene != null)
        {
            menuScenePath = UnityEditor.AssetDatabase.GetAssetPath(menuScene);
        }
        if (level1Scene != null)
        {
            level1ScenePath = UnityEditor.AssetDatabase.GetAssetPath(level1Scene);
        }
    }
#endif

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ExitGameHotkey)
        {
            Debug.Log("Quitting game");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.M) && MenuHotkey)
        {
            SceneManager.LoadScene(menuScenePath);
        }
        if ((Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Return)) && Level1Hotkey)
        {
            SceneManager.LoadScene(level1ScenePath);
        }
        if (Input.GetKeyDown(KeyCode.R) && RestartHotkey)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("CHECKPOINT"));
        }
        if (Input.GetKeyDown(KeyCode.S) && SettingsHotkey)
        {
            menuManager.ToggleSettings();
        }
    }
}
