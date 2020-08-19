using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Core Data", menuName = "Core Data")]
public class CoreData : ScriptableObject
{
    public Color textColor;
    public string nameText;
    public int iconIndex;
    public AudioClip[] voices;
    public AudioClip[] punctuations;

}
