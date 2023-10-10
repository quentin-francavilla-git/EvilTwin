using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatLauncher : MonoBehaviour
{
    public GameObject ChatBoxCanvas;
    private string[] Speakers;
    enum SpeakerPosition {LEFT = 0, RIGHT = 1}

    private string[] Script;
    public Text SpeakerName;
    public Text SpeechText;
    private int CurrentSpeechIndex = 1;

    public void LoadFile(string ScriptPath)
    {
        ChatBoxCanvas.SetActive(true); // ACTIVATE CANVAS
        // LOAD FILE CONTENT
        var TextFromFile = Resources.Load<TextAsset>(ScriptPath).text;
        Script = TextFromFile.Split(char.Parse("\n"));
        // SET VARIABLES
        Speakers = new string[] {Script[0], Script[1]};
        // LAUNCH CHAT
        UpdateChatBoxContent();
    }

    void UpdateChatBoxContent()
    {
        // UPDATE INDEX
        CurrentSpeechIndex += 1;
        // CHECK FOR LAST
        if (Script[CurrentSpeechIndex] == "END") {
            ChatBoxCanvas.SetActive(false); // DEACTIVATE CANVAS
            return;
        }
        // PARSE CONTENT
        string[] CurrentScriptLine = Script[CurrentSpeechIndex].Split(char.Parse(":"));
        int CurrentSpeakerIndex = int.Parse(CurrentScriptLine[0]);
        string CurrentLine = CurrentScriptLine[1];
        // UPDATE CONTENT
        SpeakerName.text = Speakers[CurrentSpeakerIndex];
        SpeechText.text = CurrentLine;
        if (CurrentSpeakerIndex == (int)SpeakerPosition.LEFT) {
            SpeakerName.alignment = TextAnchor.MiddleLeft;
            SpeechText.alignment = TextAnchor.UpperLeft;
        } else if (CurrentSpeakerIndex == (int)SpeakerPosition.RIGHT) {
            SpeakerName.alignment = TextAnchor.MiddleRight;
            SpeechText.alignment = TextAnchor.UpperRight;
        }
    }

    private void OnMouseClick()
    {
        if (ChatBoxCanvas.activeSelf && Input.GetMouseButtonDown(0))
            UpdateChatBoxContent();
    }

    void Update()
    {
        // CHECK FOR MOUSE EVENT
        OnMouseClick();
    }
}
