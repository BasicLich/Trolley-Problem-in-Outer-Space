using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Data", menuName = "Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public CoreData speaker;
    public CoreData getSpeaker() { return speaker; }
    [TextArea(4, 4)]
    public List<string> conversationBlocks;

    public List<string> getConversation() 
    {
        return conversationBlocks;
    }

    bool finishedTyping = true;
    public bool finished() { return finishedTyping; }
    public void skipToEnd()
    {
        finishedTyping = true;
       // TODO
    }
}
