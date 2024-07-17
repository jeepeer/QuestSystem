using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestObject", order = 1)]
public class Quest : ScriptableObject
{
    public string questName;
    public C c;
}

public enum C
{
    one,
    two
}