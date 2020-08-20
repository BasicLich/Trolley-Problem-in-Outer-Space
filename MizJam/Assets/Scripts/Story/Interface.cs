using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Interface : MonoBehaviour
{
    public TextMeshPro speakerComponent;
    public TMP_Animated textComponent;
    public DialogueAudio soundComponent;

    public GameObject[] icons;
    public GameObject arrow;

    public DialogueData[] story;
    List<string> conversation;
    CoreData speaker;
    int dialogueIndex;
    int conversationIndex;

    public bool gameOver = false;

    void Start()
    {
        // Setting up audio sources
        soundComponent = GetComponent<DialogueAudio>();
        soundComponent.voiceSource = GetComponents<AudioSource>()[0];
        soundComponent.punctuationSource = GetComponents<AudioSource>()[1];

        // Disabling icons and box
        setIcon(-1);
        arrow.SetActive(false);

        conversationIndex = 0;
        dialogueIndex = 0;
        conversation = story[dialogueIndex].getConversation();
        speaker = story[dialogueIndex].getSpeaker();
        updateDialogue();
    }

    void Update()
    {
        if (textComponent.isReading) arrow.SetActive(false);
        else arrow.SetActive(true);

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            if (!textComponent.isReading) nextConversation();
            else textComponent.skipReading();
        }
    }

    void nextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex == story.Length - 1)
        {
            gameOver = true;
        }

        conversation = story[dialogueIndex].getConversation();
        speaker = story[dialogueIndex].getSpeaker();
        updateDialogue();
    }

    void nextConversation()
    {
        if (conversationIndex == conversation.Count - 1) //Last conversation block, load next dialogue
        {
            conversationIndex = 0;
            nextDialogue();
        }
        else
        {
            conversationIndex++;
            updateDialogue();
        }
    }

    void updateDialogue()
    {
        updateSpeaker(speaker);
        updateText(conversation[conversationIndex]);
    }

    void setIcon(int index)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == index) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }

    void updateSpeaker(CoreData speaker)
    {
        // Text
        speakerComponent.color = speaker.textColor;
        speakerComponent.text = speaker.nameText;
        // Icon
        setIcon(speaker.iconIndex);
        // Sound
        soundComponent.voices = speaker.voices;
        soundComponent.punctuations = speaker.punctuations;
        
    }

    void updateText(string text)
    {
        textComponent.ReadText(text);
        arrow.SetActive(true);
    }
}
