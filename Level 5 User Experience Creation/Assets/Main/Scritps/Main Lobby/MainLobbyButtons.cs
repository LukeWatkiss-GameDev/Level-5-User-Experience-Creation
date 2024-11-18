using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using TMPro;

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

    [Header("Report")]
    public GameObject reportTooltip;
    public TMP_InputField[] reportInputFields;

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

    #region Menu Modal
    public void OpenMenuModal()
    {
        SlidePanelIn(705,menuModal);
    }

    void CloseMenuModal()
    {
        SlidePanelout(1220,menuModal);
    }

    public void SendToSupport()
    {
        // when the funtion is called send the user to the website bellow
        Application.OpenURL("https://unity.com");
    }

    public void SendReport()
    {
        reportTooltip.SetActive(true);
        foreach (var field in reportInputFields)
        {
            field.text = "";    
        }
        StartCoroutine(FadeToolTip(reportTooltip));        
    }

    IEnumerator FadeToolTip(GameObject tooltip)
    {
        // change this to make the tool tip fade after a set amount of time
        yield return new WaitForSeconds(2);
        tooltip.GetComponentInChildren<GrowAndShrinkText>().PanelShrink();
    }

    #endregion

    #region Friends Modal
/*
    public void OpenFriendsModal()
    {
        SlidePanelIn(value);
    } 

    void CloseFriendsModal()
    {
        SlidePanelout(1220,menuModal);
    }
*/
    #endregion
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

    }
    public void CloseModal()
    {
        // parent.parent will probably need to change
        GameObject curPanel = EventSystem.current.currentSelectedGameObject.transform.parent.parent.gameObject;
        //Debug.Log(curPanel);
        curPanel.GetComponentInChildren<GrowAndShrinkText>().PanelShrink(); // this will need to change 
        //backgroundDarken.SetActive(false);
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
        yield return new WaitForSeconds(.6f);
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
