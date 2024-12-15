using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CareerButtons : MonoBehaviour
{
    public Button currentActiveButton;
    public GameObject currentActiveList;

    public TMP_Text dropDownText;

    public string[] solos,duos,trios,squads; // array of character values (wins, top25 ect) for each catagory - these values are set manually
    public TMP_Text[] stats_Text; // array of Text boxes (wins, top25 ect) for each catagory

    void Start()
    {
        ChangeCharacterStats(solos); // set the character stats to solos on game start
    }
    public void ChangeVisableList(GameObject obj)
    {
        // make the current active button interactable again
        // change the curernt active button to the button that was pressed
        // make the button that was pressed non interactable
        currentActiveButton.interactable = true;
        currentActiveButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentActiveButton.interactable = false;
        
        // disable the current active list
        // make the current active list the obj that was passed in through the button
        // enable the current active list
        currentActiveList.SetActive(false);
        currentActiveList = obj;
        currentActiveList.SetActive(true);
    }

    public void ChangeDropDown()
    {
        if(dropDownText.text == "SOLOS")
        {
            ChangeCharacterStats(solos);
        }
        else if(dropDownText.text == "DUOS")
        {
            ChangeCharacterStats(duos);
        }
        else if(dropDownText.text == "TRIOS")
        {
            ChangeCharacterStats(trios);
        }
        else if(dropDownText.text == "SQUADS")
        {
            ChangeCharacterStats(squads);
        }
    }

    void ChangeCharacterStats(String[] values)
    {
        // loop through all of the textboxes and apply the corosponding values
        for (int i = 0; i < values.Length; i++)
        {
            stats_Text[i].SetText(values[i]);
        }
    }
}
