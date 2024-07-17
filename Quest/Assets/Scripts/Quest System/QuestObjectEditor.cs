using UnityEditor;

[CustomEditor(typeof(Quest))]
public class QuestObjectEditor : Editor
{
    #region SerializedProperty
    SerializedProperty questName;
    SerializedProperty questDescription;
    SerializedProperty questStart;
    SerializedProperty questStartNpc;
    SerializedProperty questStartItem;
    SerializedProperty questStartLocation;
    SerializedProperty questObjective;
    SerializedProperty questReward;
    SerializedProperty exp;
    #endregion

    private void OnEnable()
    {
        questName = serializedObject.FindProperty("questName");
        questDescription = serializedObject.FindProperty("questDescription");
        questStart = serializedObject.FindProperty("questStart");
        questStartNpc = serializedObject.FindProperty("questStartNpc");
        questStartItem = serializedObject.FindProperty("questStartItem");
        questStartLocation = serializedObject.FindProperty("questStartLocation");
        questObjective = serializedObject.FindProperty("questObjective");
        questReward = serializedObject.FindProperty("questReward");
        exp = serializedObject.FindProperty("exp");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(questName);
        EditorGUILayout.PropertyField(questDescription);
        EditorGUILayout.PropertyField(questStart);
        if (questStart.intValue == (int)QuestStart.npc)
        {
            EditorGUILayout.PropertyField(questStartNpc);
        }
        else if (questStart.intValue == (int)QuestStart.item)
        {
            EditorGUILayout.PropertyField(questStartItem);
        }
        else if (questStart.intValue == (int)QuestStart.location)
        {
            EditorGUILayout.PropertyField(questStartLocation);
        }

        EditorGUILayout.PropertyField(questObjective);
        EditorGUILayout.PropertyField(questReward);
        EditorGUILayout.PropertyField(exp);
        serializedObject.ApplyModifiedProperties();
    }
}