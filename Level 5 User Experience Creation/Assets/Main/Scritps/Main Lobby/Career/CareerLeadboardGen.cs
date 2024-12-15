
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CareerLeadboardGen : MonoBehaviour
{
    int playersToGenerate;
    CareerScriptable careerScriptableList;

    public GameObject[] ListParents;
    public GameObject playerCardPrefab;

    public Sprite darkBG;

    public int startingMaxNumber = 100;
    int currentMaxNumber;
    void Start()
    {
        // set the max number for stats
        currentMaxNumber = startingMaxNumber;

        careerScriptableList = Resources.Load<CareerScriptable>("Career"); // grab the scriptable object list
        playersToGenerate = careerScriptableList.playerCards.Length;
        int parentIndex = 0;
        // loop through all of the list parents and generate the appropriate amount of player cards 
        foreach (var parent in ListParents)
        {
            if(parentIndex == 3) // if the next list to generate is the eliminations up the max starting number
            {
                currentMaxNumber = 250; 
            }
            else
            {
                currentMaxNumber = startingMaxNumber; // reset the max number
            }
            // generate players for the list
            for (int i = 0; i < playersToGenerate; i++)
            {
                GeneratePlayer(i,ListParents[parentIndex]);
                

            }
            
            if(parentIndex != 0)
            {
                // disable all of the scrollable lists apart from the first one
                ListParents[parentIndex].transform.parent.parent.gameObject.SetActive(false);
            }
            parentIndex++;
        }
    }

    void GeneratePlayer(int index,GameObject parent)
    {
        // Check if there is a remainder when dividing by 2 - no remainder == even else odd
        // 5%2 = 1 - odd number - 5/2 = 2.5 - .5 remainder
        // 2%2 = 0 - even number - 2/2 = 1 - 0 remainder
        GameObject card = Instantiate(playerCardPrefab,parent.transform);
        Transform BG = card.transform.Find("Background");
        if(index%2 == 0)
        {
            // if the number is even change the BG colour
            BG.GetComponent<Image>().sprite = darkBG;

        }
        // Increment the rank for each player
        BG.transform.Find("Rank").GetComponent<TMP_Text>().SetText((index + 1).ToString());
        // pick a random number from the max number - 10 to the max number
        // this ensures the leaderboard numbers go from big to small
        currentMaxNumber = Random.Range(currentMaxNumber - 15,currentMaxNumber);
        // if the current max number is less than 0 set it back to 0 to avoid any negative numbers
        if(currentMaxNumber < 0) currentMaxNumber = 0; 
        // set the number on the player card
        BG.transform.Find("Number").GetComponent<TMP_Text>().SetText(currentMaxNumber.ToString());
        // set the player name on the card
        BG.transform.Find("Name").GetComponent<TMP_Text>().SetText(careerScriptableList.playerCards[index].playerName);
    }
}
