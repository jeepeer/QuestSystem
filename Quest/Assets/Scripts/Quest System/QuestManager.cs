using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestUI))]
public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> quests;
    private List<Quest> activeQuests;
    private QuestUI questUI;
    public Dictionary<string, Quest> questDictionary;

    private void Start()
    {
        if (!TryGetComponent<QuestUI>(out questUI))
        {
            Debug.LogError($"Could not find QuestUI");
        }

        activeQuests = new List<Quest>();
        questDictionary = new Dictionary<string, Quest>();

        if (quests.Count <= 0) { return; }
        foreach (var quest in quests)
        {
            questDictionary.Add(GetDictionaryValue(quest), quest);
        }
    }

    private string GetDictionaryValue(Quest quest)
    {
        switch (quest.questObjective)
        {
            case QuestObjective.talkToNpc:
                return quest.questNpc.ToString();
            case QuestObjective.collectItems:
                return quest.questItem.ToString();
            case QuestObjective.getToLocation:
                return quest.questLocation.ToString();
            default:
                break;
        }

        return "";
    }

    public void HandleQuest(Quest quest)
    {
        // If there is a quest and we haven't started it; start it
        if (TryToStartQuest(quest)) { return; }

        CompleteQuest(quest);
    }

    private bool TryToStartQuest(Quest quest)
    {
        if (!quest) { return false; }
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            questUI.DisplayQuest(quest);
            if (quest.objectToSpawn) { Instantiate(quest.objectToSpawn); }
            return true;
        }

        return false;
    }

    public void CompleteQuest(Quest quest)
    {
        int index = -1;
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (quest.questNpc == activeQuests[i].questNpc || quest.questItem == activeQuests[i].questItem)
            {
                index = i;
                break;
            }
        }

        if (index >= 0)
        {
            activeQuests.RemoveAt(index);
            // remove item from inventory
            // gain exp
            
        }
    }
}