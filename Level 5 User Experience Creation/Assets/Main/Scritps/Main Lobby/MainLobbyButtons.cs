using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class MainLobbyButtons : MonoBehaviour
{

    public GameObject playScreen,questsScreen,rhupassScreen,lockerScreen,shopScreen, careerScreen;
    public GameObject backgroundDarken;

    [Header("Modals")]
    public GameObject selectModeModal;
    public GameObject menuModal;
    public bool modalIsOpen = false;

    bool canOpenModal = true;
    public GameObject currentScreen;
    public Button currentUpButton;

    void Start()
    {
        SetPanelsNonActive();
    }

    void Update()
    {
        if(modalIsOpen & Input.GetMouseButtonDown(0))
        {
            // check if the user has clicked outside of the modal
            GameObject curObject = EventSystem.current.currentSelectedGameObject;
            Debug.Log(curObject);
            if(curObject == backgroundDarken)
            {
                CloseMenuModal();
            }
        }
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

    public void OpenMenuModal()
    {
        SlidePanelIn(705,menuModal);
    }

    void CloseMenuModal()
    {
        SlidePanelout(1220,menuModal);
    }

/*
    public void OpenFriendsModal()
    {
        SlidePanelIn(value);
    } */

    public void OpenSelectModeModal()
    {
        if(canOpenModal)
        {
            canOpenModal = false;
            selectModeModal.SetActive(true);
            backgroundDarken.SetActive(true);
        }
    }


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
        curPanel.GetComponentInChildren<GrowAndShrinkText>().PanelShrink(); // this will need to change 
        backgroundDarken.SetActive(false);
        StartCoroutine(ModalDelay());

    }

    void SlidePanelIn(float value, GameObject panel)
    {
        panel.transform.DOLocalMoveX(value,.25f);
        backgroundDarken.SetActive(true);
        modalIsOpen = true;
    }

    void SlidePanelout(float value,GameObject panel)
    {
        panel.transform.DOLocalMoveX(value,.25f);
        backgroundDarken.SetActive(false);
        modalIsOpen = false;
    }


    void MoveButtonDown(Button OBJ)
    {
        OBJ.transform.DOLocalMoveY(-519.75f,0.5f);
    }

    void MoveButtonUp(Button OBJ)
    {
        OBJ.transform.DOLocalMoveY(-503.5f,0.5f);
    }

    IEnumerator ModalDelay() 
    {
        yield return new WaitForSeconds(1.1f);
        canOpenModal = true;
    }
    void SetPanelsNonActive() // set all panels ,exept the main menu, to false
    {
        questsScreen.SetActive(false);
        rhupassScreen.SetActive(false);
        lockerScreen.SetActive(false);
        shopScreen.SetActive(false);
        careerScreen.SetActive(false);
        backgroundDarken.SetActive(false);
        selectModeModal.SetActive(false);
    }


}