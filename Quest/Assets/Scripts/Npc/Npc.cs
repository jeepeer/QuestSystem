using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public bool hasQuest = false;
    public Quest quest;
    public bool LOL() { return hasQuest; }
}