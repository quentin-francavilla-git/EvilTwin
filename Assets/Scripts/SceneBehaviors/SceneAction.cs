/*
File: MenuAction.cs

Author: Corentin ROZET
Email: corentin.rozet@epitech.eu
Creation date: 2021, October 04

Copyright 2021, Corentin ROZET, Johan SAFFRE
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAction : MonoBehaviour
{
	public Animator fader;

    Canvas canvas;

    private void Awake() {
        canvas = GetComponentInChildren<Canvas>();

        if (SceneManager.GetActiveScene().name == "Menu")
            canvas.gameObject.SetActive(false);
    }
    public void FadeOut(string sceneName)
    {
        // Play Sound
        if (sceneName == "Swamp")
            FindObjectOfType<AudioManager>().Play("LaunchLevel");
        PlayerPrefs.SetString("sceneToLoad", sceneName);
        PlayerPrefs.SetInt("sceneLoaded", 1);
        fader.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (PlayerPrefs.GetInt("sceneLoaded") == 1) {
            PlayerPrefs.SetInt("sceneLoaded", 0);
            LoadScene(PlayerPrefs.GetString("sceneToLoad"));
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        FindObjectOfType<AudioManager>().Play("QuitGame");

        StartCoroutine(WaitAndQuit(1.5f));

    }

    IEnumerator WaitAndQuit(float second)
    {
        yield return new WaitForSeconds(1.3f);

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
