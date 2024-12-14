using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGenerator : MonoBehaviour
{
    List<int> questsInUse = new List<int>();

    int questsToGenerate;

    QuestScriptableList questScriptableList;

    public GameObject listParent;
    public GameObject questPrefab;

    void Start()
    {

        questScriptableList = Resources.Load<QuestScriptableList>("Quests"); // grab the scriptable object list
        questsToGenerate = Random.Range(7,questScriptableList.listOfQuests.Length); // chose an amount of quests to generate 
        for (int i = 0; i < questsToGenerate; i++)
        {
            
            int randomInt = Random.Range(0,questScriptableList.listOfQuests.Length); // 
            // if the quest is aready being used go back through the loop
            if(questsInUse.Contains(randomInt))
            {
                i--;
            }
            // if the quest is not in use generate the quest and add it to the list of generated quests
            else if(!questsInUse.Contains(randomInt))
            {
                GenerateQuest(randomInt);
                questsInUse.Add(randomInt);
            }
        }
    }

    void GenerateQuest(int index)
    {
        // create new quest obj and parent to the grid content

        GameObject quest = Instantiate(questPrefab,listParent.transform);
        Quest questScriptable = questScriptableList.listOfQuests[index];
        // assign values from the list of quests
        quest.transform.Find("sprite").GetComponent<Image>().sprite = questScriptable.icon;
        // set the new sprite to the native size
        quest.transform.Find("sprite").GetComponent<Image>().SetNativeSize();
        // randomize the XP amount for completing a quest
        quest.transform.Find("XP amount").GetComponent<TMP_Text>().SetText(Random.Range(10,50) + "K");
        quest.transform.Find("Title").GetComponent<TMP_Text>().SetText(questScriptable.title);
        quest.transform.Find("Desc").GetComponent<TMP_Text>().SetText(questScriptable.description);
        // randomize the time to clomplete each quest
        quest.transform.Find("Time").GetComponent<TMP_Text>().SetText(Random.Range(1,4) +"d "+ Random.Range(1,59) + "h");
        quest.transform.Find("Completion").GetComponent<TMP_Text>().SetText(questScriptable.completionStatus);


    }

}
