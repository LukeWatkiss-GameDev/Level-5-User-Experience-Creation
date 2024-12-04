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

    // Start is called before the first frame update
    void Start()
    {

        questScriptableList = Resources.Load<QuestScriptableList>("Quests");
        questsToGenerate = Random.Range(7,questScriptableList.listOfQuests.Length);
        
        for (int i = 0; i < questsToGenerate; i++)
        {

            int randomInt = Random.Range(0,questScriptableList.listOfQuests.Length);
            if(questsInUse.Contains(randomInt))
            {
                i--;
            }
            else if(!questsInUse.Contains(randomInt))
            {
                GenerateQuest(randomInt);
                questsInUse.Add(randomInt);
            }
        }
    }

    void GenerateQuest(int index)
    {
        // create new friend obj and parent to the grid content

        GameObject quest = Instantiate(questPrefab,listParent.transform);
        
        // assign values from the list of quests
        quest.transform.Find("sprite").GetComponent<Image>().sprite = questScriptableList.listOfQuests[index].icon;
        // set the new sprite to the native size
        quest.transform.Find("sprite").GetComponent<Image>().SetNativeSize();
        // randomize the XP amount for completing a quest
        quest.transform.Find("XP amount").GetComponent<TMP_Text>().SetText(Random.Range(10,50) + "K");
        quest.transform.Find("Title").GetComponent<TMP_Text>().SetText(questScriptableList.listOfQuests[index].title);
        quest.transform.Find("Desc").GetComponent<TMP_Text>().SetText(questScriptableList.listOfQuests[index].description);
        // randomize the time to clomplete each quest
        quest.transform.Find("Time").GetComponent<TMP_Text>().SetText(Random.Range(1,4) +"d "+ Random.Range(1,59) + "h");
        quest.transform.Find("Completion").GetComponent<TMP_Text>().SetText(questScriptableList.listOfQuests[index].completionStatus);


    }

}
