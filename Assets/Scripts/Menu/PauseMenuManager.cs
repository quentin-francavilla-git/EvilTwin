using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public bool isPaused = false;
    bool isSettingsOn = false;

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject settingsMenu;

    AudioManager audioManager;

    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    void Update()
    {
        if (TriggerPauseKey()) {
            SwitchPauseState();
        }
        if (TriggerBackToPauseKey()) {
            BackToPause();
        }
    }

    public void SwitchPauseState () {
        if (isPaused) {
            Resume();
            return;
        }
        Pause();
    }

    public void BackToPause() {
        settingsMenu.SetActive(false);
        Pause();
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToSettings() {
        isSettingsOn = true;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public bool TriggerPauseKey()
    {
        return Input.GetKeyDown(KeyCode.Escape) && !isSettingsOn;
    }

    public bool TriggerBackToPauseKey()
    {
        return Input.GetKeyDown(KeyCode.Escape) && isSettingsOn;
    }
}
