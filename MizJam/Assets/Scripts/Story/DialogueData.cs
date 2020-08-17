using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Data", menuName = "Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string speaker;
    [TextArea(4, 4)]
    public List<string> conversationBlocks;
    public int conversationIndex;

    private void Awake()
    {
        conversationIndex = -1;
    }

    public string getNextBlock() 
    {
        if (conversationIndex == conversationBlocks.Count - 1)
        {
            dialogueEnded = true;
            return "";
        }
        else
        {
            conversationIndex++;
            return conversationBlocks[conversationIndex];
        }
    }

    bool finishedTyping = true;
    public bool finished() { return finishedTyping; }
    public void skipToEnd()
    {
        finishedTyping = true;
       // TODO
    }

    bool dialogueEnded = false;
    public bool ended() { return dialogueEnded; }
}
