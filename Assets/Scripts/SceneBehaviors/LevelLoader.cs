using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 0.5f;

    AudioManager audioManager;

    private void Awake() {
        audioManager  = FindObjectOfType<AudioManager>();
    }

    public void LoadLevel(string level) {
       StartCoroutine(MakeTransitionAndLoad(level));
    }

    IEnumerator MakeTransitionAndLoad(string level) {
        Time.timeScale = 1f;

        transition.SetTrigger("Start");
        audioManager.Play("LaunchLevel");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(level);
    }

    public void QuitGame() {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("QuitGame");

        StartCoroutine(WaitAndQuit(0.8f));
    }

    IEnumerator WaitAndQuit(float second)
    {
        yield return new WaitForSeconds(second);

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
