using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestObject", order = 1)]
public class Quest : ScriptableObject
{
    public string questName;
    public QuestStart questStart;
    public QuestStartNpc questStartNpc;
    public QuestStartItem questStartItem;
    public QuestStartLocation questStartLocation;
    public QuestObjective questObjective;
    public QuestReward questReward;
    public int exp;
}