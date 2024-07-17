using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestUI))]
public class QuestManager : MonoBehaviour
{
    private List<Quest> activeQuests;
    private QuestUI questUI;

    private void Start()
    {
        if (!TryGetComponent<QuestUI>(out questUI))
        {
            Debug.LogError($"Could not find QuestUI");
        }
        activeQuests = new List<Quest>();
    }

    public void HandleQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
        }

        questUI.DisplayQuestText(quest);
        return;
    }
}
