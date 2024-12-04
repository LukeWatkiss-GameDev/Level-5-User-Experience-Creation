using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "ScriptableObjects/questList")]
public class QuestScriptableList : ScriptableObject
{
    public Quest[] listOfQuests;

}

[System.Serializable]
public class Quest
{
    public Sprite icon;
    public string title;
    public string description;
    public string completionStatus;
}
