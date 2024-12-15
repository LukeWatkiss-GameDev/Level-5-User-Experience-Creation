using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    [Header("Side buttons")]
    public Button currentSelectedButton;
    public GameObject currentActiveScreen;

    #region Graphics Setting Variables

    [Header("Graphics Settings")]
    [Header("Resolution")]
    public string[] resolutionSettings;
    public GameObject[] resSliderSections;
    int currentResSetting = 4; // value set to the max amount of settings
    public TMP_Text resoulutionText;

    [Header("Brightness")]
    public Slider brightnessSlider;
    public TMP_Text brightPercentText;
    
    [Header("Contrast")]
    public Slider contrastSlider;
    public TMP_Text contPercentText;

    [Header("Colour Blind Mode")]
    public string[] CBMSettings;
    public GameObject[] CBMSliderSections;
    int currentCBMSetting = 3; // value set to the max amount of settings
    public TMP_Text CBMText;

    [Header("Show FPS")]
    public GameObject[] FPSSliderSections;
    int currentFPSSetting = 0; // value set to the max amount of settings
    public TMP_Text FPSText;

    [Header("Power Saving mode")]
    public GameObject[] PSMSliderSections;
    int currentPSMSetting = 1; // value set to the max amount of settings
    public TMP_Text PSMText;

    [Header("Mixed")]
    public Sprite sliderSectionActive;
    public Sprite sliderSectionInactive;
    public string[] OnAndOffSettings;

    #endregion
    #region Game Setting variables

    [Header("Game")]
    [Header("Toggle Sprint")]
    public GameObject[] TSSliderSections;
    int currentTSSetting = 1; // value set to the max amount of settings
    public TMP_Text TSText;

    [Header("Sprint By Default")]
    public GameObject[] SBDSliderSections;
    int currentSBDSetting = 1; // value set to the max amount of settings
    public TMP_Text SBDText;

    [Header("Sprint Cancels Reload")]
    public GameObject[] SCRSliderSections;
    int currentSCRSetting = 1; // value set to the max amount of settings
    public TMP_Text SCRText;

    [Header("Auto Open Doors")]
    public GameObject[] AODSliderSections;
    int currentAODSetting = 1; // value set to the max amount of settings
    public TMP_Text AODText;
    
    [Header("Hold To Swap Pickup")]
    public GameObject[] HTSSliderSections;
    int currentHTSSetting = 1; // value set to the max amount of settings
    public TMP_Text HTSText;
    
    [Header("Hold To Swap Pickup")]
    public GameObject[] TTSliderSections;
    int currentTTSetting = 1; // value set to the max amount of settings
    public TMP_Text TTText;
    
    [Header("Mark While Targeting")]
    public GameObject[] MWTSliderSections;
    int currentMWTSetting = 1; // value set to the max amount of settings
    public TMP_Text MWTText;
    
    [Header("Auto Pickup Weapons")]
    public GameObject[] APWSliderSections;
    int currentAPWSetting = 1; // value set to the max amount of settings
    public TMP_Text APWText;
    
    #endregion

    void Update()
    {
        UpdateGraphicsSliders();
    }

    public void SideButtonClicked(GameObject obj)
    {
        // make the current selected button interactable again
        // find the button that was just pressed and set it to the current selected button 
        // make the current selected button non interactable
        currentSelectedButton.interactable = true;
        currentSelectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentSelectedButton.interactable = false;

        // disable the current active screen
        // make the current active screen the obj that was passed in through the button
        // enable the current active screen
        currentActiveScreen.SetActive(false);
        currentActiveScreen = obj;
        currentActiveScreen.SetActive(true);
    }

    #region Graphics settings
    void UpdateGraphicsSliders()
    {
        // update the brightness slider percentage
        brightPercentText.SetText(brightnessSlider.value + "%");
        // update the contrast slider percentage 
        contPercentText.SetText(contrastSlider.value + "%");
    }
    public void ChangeRes(bool left)
    {
        currentResSetting = ChangeSettingValue(currentResSetting,resolutionSettings,left);
        UpdateSections(resSliderSections,currentResSetting);
        // set the text to the current selected resolution
        resoulutionText.SetText(resolutionSettings[currentResSetting]);
        // add changing resolution Functionality here
    }

    public void ChangeColourBlindMode(bool left)
    {
        currentCBMSetting = ChangeSettingValue(currentCBMSetting,CBMSettings,left);
        UpdateSections(CBMSliderSections,currentCBMSetting);
        // set the text to the current selected colour blind mode
        CBMText.SetText(CBMSettings[currentCBMSetting]);
        // add changing brightness Functionality here
    }

    public void ChangeFPSMode(bool left)
    {   
        currentFPSSetting = ChangeSettingValue(currentFPSSetting,OnAndOffSettings,left);
        UpdateSections(FPSSliderSections,currentFPSSetting);
        FPSText.SetText(OnAndOffSettings[currentFPSSetting]);
        // add showing fps Functionality here
    }

    public void ChangePowerSavingMode(bool left)
    {
        currentPSMSetting = ChangeSettingValue(currentPSMSetting,OnAndOffSettings,left);
        UpdateSections(PSMSliderSections,currentPSMSetting);
        PSMText.SetText(OnAndOffSettings[currentPSMSetting]);
        // add changing power saving mode Functionality here
    }
    #endregion
    #region Game Settings

    public void ChangeToggleSprintMode(bool left)
    {
        currentTSSetting = ChangeSettingValue(currentTSSetting,OnAndOffSettings,left);
        UpdateSections(TSSliderSections,currentTSSetting);
        TSText.SetText(OnAndOffSettings[currentTSSetting]);
        // add changing toggle to sprint Functionality here
    }
    
    public void ChangeSprintByDefaultMode(bool left)
    {
        currentSBDSetting = ChangeSettingValue(currentSBDSetting,OnAndOffSettings,left);
        UpdateSections(SBDSliderSections,currentSBDSetting);
        SBDText.SetText(OnAndOffSettings[currentSBDSetting]);
        // add changing sprint to default Functionality here
    }

    public void ChangeSprintCancelsReload(bool left)
    {
        currentSCRSetting = ChangeSettingValue(currentSCRSetting,OnAndOffSettings,left);
        UpdateSections(SCRSliderSections,currentSCRSetting);
        SCRText.SetText(OnAndOffSettings[currentSCRSetting]);
        // add sprint to cancel reload Functionality here 
    }

    public void ChangeAutoOpenDoorMode(bool left)
    {
        currentAODSetting = ChangeSettingValue(currentAODSetting,OnAndOffSettings,left);
        UpdateSections(AODSliderSections,currentAODSetting);
        AODText.SetText(OnAndOffSettings[currentAODSetting]);
        // add auto oped doors Functionality here
    }

    public void ChangeHoldToSwapMode(bool left)
    {
        currentHTSSetting = ChangeSettingValue(currentHTSSetting,OnAndOffSettings,left);
        UpdateSections(HTSSliderSections,currentHTSSetting);
        HTSText.SetText(OnAndOffSettings[currentHTSSetting]);
        // add hold to swap Functionality here
    }

    public void ChangeToggleTargetingMode(bool left)
    {
        currentTTSetting = ChangeSettingValue(currentTTSetting,OnAndOffSettings,left);
        UpdateSections(TTSliderSections,currentTTSetting);
        TTText.SetText(OnAndOffSettings[currentTTSetting]);
        // add toggle targeting mode Functionality here
    }

    public void ChangeMarkWhileTargetingMode(bool left)
    {
        currentMWTSetting = ChangeSettingValue(currentMWTSetting,OnAndOffSettings,left);
        UpdateSections(MWTSliderSections,currentMWTSetting);
        MWTText.SetText(OnAndOffSettings[currentMWTSetting]);
        // add mark while targeting Functionality here
    }

    public void ChangeAutoPickupWeaponsMode(bool left)
    {
        currentAPWSetting = ChangeSettingValue(currentAPWSetting,OnAndOffSettings,left);
        UpdateSections(APWSliderSections,currentAPWSetting);
        APWText.SetText(OnAndOffSettings[currentAPWSetting]);
        // add auto weapon pick up Functionality here
    }

    #endregion

    void UpdateSections(GameObject[] sections, int currentSetting)
    {
        // loop through all sections to find which one matches the current resolution setting and enable it
        // disable all others
        foreach (var section in sections)
        {
            if(section.name == currentSetting.ToString())
            {
                section.GetComponent<Image>().sprite = sliderSectionActive;
            }
            else
            {
                section.GetComponent<Image>().sprite = sliderSectionInactive;
            }
        }
    }

    int ChangeSettingValue(int currentSetting, string[] settings, bool left)
    {
        // check if reducing the currentSetting int will be less than 0
        // if so set it to the amount of settings
        // if not decrease the currentSetting by 1
        if(left)
        {
            if(currentSetting - 1 < 0)
            {
                currentSetting = settings.Length - 1;
            }
            else
            {
                currentSetting--;
            }
        }
        // check if reducing the currentSetting int will be more than the amount of settings
        // if so set it to 0
        // if not increase the currentSetting by 1
        else
        {
            if(currentSetting + 1 > settings.Length - 1)
            {
                currentSetting = 0;
            }
            else
            {
                currentSetting++;
            }
        }
        // return the int value
        return currentSetting;
    }
}

