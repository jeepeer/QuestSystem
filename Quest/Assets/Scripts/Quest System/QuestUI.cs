using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;

    public void DisplayQuestText(Quest quest)
    {
        questNameText?.SetText(quest.questName);
        questDescriptionText?.SetText(quest.questDescription);
    }
}