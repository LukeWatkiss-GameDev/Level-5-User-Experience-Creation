using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class MainLobbyButtons : MonoBehaviour
{


    public Button currentUpButton;


    public void ButtonSelected()
    {
        if(currentUpButton != null)
        {
            MoveButtonDown(currentUpButton); // move the current selected button back down
            currentUpButton.interactable = true;
            
        }
        Button curButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentUpButton = curButton;
        currentUpButton.interactable = false;
        MoveButtonUp(currentUpButton);
        
        // will have to add changing panels somewhere in here
        // also find out which panel 
        // good luck 

    }

    void MoveButtonDown(Button OBJ)
    {
        OBJ.transform.DOLocalMoveY(-519.75f,0.5f);
    }

    void MoveButtonUp(Button OBJ)
    {
        OBJ.transform.DOLocalMoveY(-503.5f,0.5f);
    }


}
