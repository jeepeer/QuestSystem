using UnityEditor;

[CustomEditor(typeof(Quest))]
public class QuestObjectEditor : Editor
{
    #region SerializedProperty
    SerializedProperty questName;
    SerializedProperty questDescription;
    SerializedProperty questNpc;
    SerializedProperty questItem;
    SerializedProperty questLocation;
    SerializedProperty questObjective;
    SerializedProperty questReward;
    SerializedProperty exp;
    SerializedProperty objectToSpawn;
    #endregion

    private void OnEnable()
    {
        questName = serializedObject.FindProperty("questName");
        questDescription = serializedObject.FindProperty("questDescription");
        questNpc = serializedObject.FindProperty("questNpc");
        questItem = serializedObject.FindProperty("questItem");
        questLocation = serializedObject.FindProperty("questLocation");
        questObjective = serializedObject.FindProperty("questObjective");
        questReward = serializedObject.FindProperty("questReward");
        exp = serializedObject.FindProperty("exp");
        objectToSpawn = serializedObject.FindProperty("objectToSpawn");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(questName);
        EditorGUILayout.PropertyField(questDescription);

        EditorGUILayout.PropertyField(questObjective);
        if (questObjective.intValue == (int)QuestObjective.collectItems)
        {
            EditorGUILayout.PropertyField(questItem);
        }
        else if (questObjective.intValue == (int)QuestObjective.getToLocation)
        {
            EditorGUILayout.PropertyField(questLocation);
        }
        else if (questObjective.intValue == (int)QuestObjective.talkToNpc)
        {
            EditorGUILayout.PropertyField(questNpc);
        }

        EditorGUILayout.PropertyField(questReward);
        EditorGUILayout.PropertyField(exp);
        EditorGUILayout.PropertyField(objectToSpawn);

        serializedObject.ApplyModifiedProperties();
    }
}