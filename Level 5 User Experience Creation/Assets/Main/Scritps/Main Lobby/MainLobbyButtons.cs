using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class MainLobbyButtons : MonoBehaviour
{

    public GameObject playScreen,questsScreen,rhupassScreen,lockerScreen,shopScreen, careerScreen;

    public GameObject currentScreen;
    public Button currentUpButton;

    void Start()
    {
        SetPanelsNonActive();
    }

    #region SwitchToX 
    
    public void SwitchToPlay()
    {
        ButtonSelected(playScreen);
        
    }
    public void SwitchToQuests()
    {
        ButtonSelected(questsScreen);
        
    }
    public void SwitchToRhupass()
    {
        ButtonSelected(rhupassScreen);
        
    }
    public void SwitchToLocker()
    {
        ButtonSelected(lockerScreen);
        
    }
    public void SwitchToShop()
    {
        ButtonSelected(shopScreen);
        
    }
    public void SwitchToCareer()
    {
        ButtonSelected(careerScreen);
        
    }

    #endregion

/*   public void OpenFriendsModal()
    {
        SlidePanelIn(value);
    }

    public void OpenMenuModal()
    {
        SlidePanelIn(value);
    } */


    public void ButtonSelected(GameObject panel)
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

        // disable the current active screen and then enable the new screen
        currentScreen.SetActive(false);
        currentScreen = panel;
        currentScreen.SetActive(true);
        
        // will have to add changing panels somewhere in here
        // also find out which panel 
        // good luck 

    }
    public void CloseModal()
    {
        // parent.parent will probably need to change
        GameObject curPanel = EventSystem.current.currentSelectedGameObject.transform.parent.parent.gameObject;
        //Debug.Log(curPanel);
        curPanel.GetComponentInChildren<GrowAndShrinkText>().panelShrink(); // this will need to change 

    }

    void SliderPanelIn(float value)
    {
        
    }

    void SliderPanelout(float value)
    {

    }


    void MoveButtonDown(Button OBJ)
    {
        OBJ.transform.DOLocalMoveY(-519.75f,0.5f);
    }

    void MoveButtonUp(Button OBJ)
    {
        OBJ.transform.DOLocalMoveY(-503.5f,0.5f);
    }
    void SetPanelsNonActive() // set all panels ,exept the main menu, to false
    {
        questsScreen.SetActive(false);
        rhupassScreen.SetActive(false);
        lockerScreen.SetActive(false);
        shopScreen.SetActive(false);
        careerScreen.SetActive(false);
    }


}
