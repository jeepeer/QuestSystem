using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Npc : MonoBehaviour
{
    public Items itemType;
    private UnityAction<Quest> action;
    private QuestManager questManager;

    private void Start()
    {
        if (itemType.ToString().Contains("quest", System.StringComparison.OrdinalIgnoreCase))
        {
            questManager = FindObjectOfType<QuestManager>();
            if (!questManager) { return; }
            action += questManager.HandleQuest;
        }
    }

    public void OnInteracted()
    {
        action?.Invoke(questManager.questDictionary[itemType.ToString()]);

        if (action != null)
        {
            action -= questManager.HandleQuest;
            itemType = Items.none;
        }
    }
}