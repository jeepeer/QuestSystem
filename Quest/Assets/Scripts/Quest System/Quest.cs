using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestObject", order = 1)]
public class Quest : ScriptableObject
{
    public string questName;
    public string questDescription;
    public QuestNpc questNpc;
    public Items questItem;
    public QuestLocation questLocation;
    public QuestObjective questObjective;
    public QuestReward questReward;
    public int exp;
    public GameObject objectToSpawn;
}