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

    [Header("Game Settings")]
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

    [Header("Region")]
    public string[] regionSettings;
    public GameObject[] regionSliderSections;
    int currentRegionSetting = 4; // value set to the max amount of settings
    public TMP_Text regionText;
    [Header("Language")]
    public string[] languageSettings;
    public GameObject[] languageSliderSections;
    int currentLanguageSetting = 4; // value set to the max amount of settings
    public TMP_Text languageText;
    
    #endregion
    #region Audio Setting variables

    [Header("Audio Settings")]
    [Header("Main volume")]
    public Slider mainAudioSlider;
    public TMP_Text mainAudioPercentText;
    
    [Header("Music volume")]
    public Slider musicAudioSlider;
    public TMP_Text musicAudioPercentText;
    
    [Header("SFX volume")]
    public Slider SFXSlider;
    public TMP_Text SFXPercentText;

    [Header("Dialogue volume")]
    public Slider dialogueAudioSlider;
    public TMP_Text dialogueAudioPercentText;
    
    [Header("Cimematics volume")]
    public Slider cinematicsSlider;
    public TMP_Text cinematicsPercentText;

    [Header("Sound Quality")]
    public string[] soundQualitySettings;
    public GameObject[] soundQualitySliderSections;
    int currentSoundQualitySetting = 2; // value set to the max amount of settings
    public TMP_Text soundQualityText;
    
    [Header("Subtitles")]
    public GameObject[] subtitleSliderSections;
    int currentSubtitleSetting = 0;
    public TMP_Text subtitleText;
    
    [Header("Voice Chat")]
    public GameObject[] voiceChatSliderSections;
    int currentVoiceChatSetting = 1;
    public TMP_Text voiceChatText;
    
    [Header("Visualise SFX")]
    public GameObject[] visualiseSFXSliderSections;
    int currentVisualiseSFXSetting = 1;
    public TMP_Text visualiseSFXText;

    #endregion
    #region Account Setting Variables
    
    [Header("Account Settings")]
    [Header("Filter Mature Language")]
    public GameObject[] FMLSliderSections;
    int currentFMLSetting = 1;
    public TMP_Text FMLText;
    
    [Header("Accept Friend Requests")]
    public GameObject[] AFRSliderSections;
    int currentAFRSetting = 1;
    public TMP_Text AFRText;
    
    [Header("Party Joinable")]
    public GameObject[] partyJoinableSliderSections;
    int currentPartyJoinableSetting = 1;
    public TMP_Text partyJoinableText;
    
    [Header("Public game stats")]
    public GameObject[] PGSSliderSections;
    int currentPGSSetting = 1;
    public TMP_Text PGSText;
    
    [Header("Display Name")]
    public GameObject[] displayNameSliderSections;
    int currentDisplayNameSetting = 1;
    public TMP_Text displayNameText;
    
    [Header("Show level in feed")]
    public GameObject[] showLevelSliderSections;
    int currentShowLevelSetting = 1;
    public TMP_Text showLevelText;
    
    [Header("Hide player names")]
    public GameObject[] HPNSliderSections;
    int currentHPNSetting = 1;
    public TMP_Text HPNText;


    #endregion
    void Update()
    {
        UpdateGraphicsSliders(); // update all graphic settings sliders 
        UpdateAudioSliders(); // update all audio settings sliders
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

    #region Graphics Settings
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
    public void ChangeRegionMode(bool left)
    {
        currentRegionSetting = ChangeSettingValue(currentRegionSetting,regionSettings,left);
        UpdateSections(regionSliderSections,currentRegionSetting);
        regionText.SetText(regionSettings[currentRegionSetting]);
        // add region changing Functionality here
    }
    public void ChangeLanguageMode(bool left)
    {
        currentLanguageSetting = ChangeSettingValue(currentLanguageSetting,languageSettings,left);
        UpdateSections(languageSliderSections,currentLanguageSetting);
        languageText.SetText(languageSettings[currentLanguageSetting]);
        // add language changing Functionality here
    }

    #endregion
    #region Auido Settings

    void UpdateAudioSliders()
    {
        // update the main audio slider percentage
        mainAudioPercentText.SetText(mainAudioSlider.value + "%");
        // update the music audio slider percentage
        musicAudioPercentText.SetText(musicAudioSlider.value + "%");
        // update the SFX audio slider percentage
        SFXPercentText.SetText(SFXSlider.value + "%");
        // update the dialogue audio slider percentage
        dialogueAudioPercentText.SetText(dialogueAudioSlider.value + "%");
        // update the main audio slider percentage
        cinematicsPercentText.SetText(cinematicsSlider.value + "%");

    }

    public void ChangeSoundQualityMode(bool left)
    {
        currentSoundQualitySetting = ChangeSettingValue(currentSoundQualitySetting,soundQualitySettings,left);
        UpdateSections(soundQualitySliderSections,currentSoundQualitySetting);
        soundQualityText.SetText(soundQualitySettings[currentSoundQualitySetting]);
        // add changing sound quality Functionality here
    }
    public void ChangeSubtitleMode(bool left)
    {
        currentSubtitleSetting = ChangeSettingValue(currentSubtitleSetting,OnAndOffSettings,left);
        UpdateSections(subtitleSliderSections,currentSubtitleSetting);
        subtitleText.SetText(OnAndOffSettings[currentSubtitleSetting]);
        // add changing subtitle Functionality here
    }
    public void ChangeVoiceChatMode(bool left)
    {
        currentVoiceChatSetting = ChangeSettingValue(currentVoiceChatSetting,OnAndOffSettings,left);
        UpdateSections(voiceChatSliderSections,currentVoiceChatSetting);
        voiceChatText.SetText(OnAndOffSettings[currentVoiceChatSetting]);
        // add changing Voice chat Functionality here
    }
    public void ChangeViualiseSFXMode(bool left)
    {
        currentVisualiseSFXSetting = ChangeSettingValue(currentVisualiseSFXSetting,OnAndOffSettings,left);
        UpdateSections(visualiseSFXSliderSections,currentVisualiseSFXSetting);
        visualiseSFXText.SetText(OnAndOffSettings[currentVisualiseSFXSetting]);
        // add changing visualise sound effects Functionality here
    }

    #endregion
    #region Account Settings

    public void ChangeMatureLanguageMode(bool left)
    {
        currentFMLSetting = ChangeSettingValue(currentFMLSetting,OnAndOffSettings,left);
        UpdateSections(FMLSliderSections,currentFMLSetting);
        FMLText.SetText(OnAndOffSettings[currentFMLSetting]);
        // add changing Filter mature language Functionality here
    }
    public void ChangeAcceptFriendRequestsMode(bool left)
    {
        currentAFRSetting = ChangeSettingValue(currentAFRSetting,OnAndOffSettings,left);
        UpdateSections(AFRSliderSections,currentAFRSetting);
        AFRText.SetText(OnAndOffSettings[currentAFRSetting]);
        // add changing Filter mature language Functionality here
    }
    public void ChangePartyJoinableMode(bool left)
    {
        currentPartyJoinableSetting = ChangeSettingValue(currentPartyJoinableSetting,OnAndOffSettings,left);
        UpdateSections(partyJoinableSliderSections,currentPartyJoinableSetting);
        partyJoinableText.SetText(OnAndOffSettings[currentPartyJoinableSetting]);
        // add changing party joinable Functionality here
    }
    public void ChangeGameStatsMode(bool left)
    {
        currentPGSSetting = ChangeSettingValue(currentPGSSetting,OnAndOffSettings,left);
        UpdateSections(PGSSliderSections,currentPGSSetting);
        PGSText.SetText(OnAndOffSettings[currentPGSSetting]);
        // add changing party joinable Functionality here
    }
    public void ChangeDisplayNameMode(bool left)
    {
        currentDisplayNameSetting = ChangeSettingValue(currentDisplayNameSetting,OnAndOffSettings,left);
        UpdateSections(displayNameSliderSections,currentDisplayNameSetting);
        displayNameText.SetText(OnAndOffSettings[currentDisplayNameSetting]);
        // add changing Display name Functionality here
    }
    public void ChangeShowLevelInFeedMode(bool left)
    {
        currentShowLevelSetting = ChangeSettingValue(currentShowLevelSetting,OnAndOffSettings,left);
        UpdateSections(showLevelSliderSections,currentShowLevelSetting);
        showLevelText.SetText(OnAndOffSettings[currentShowLevelSetting]);
        // add changing show level in feed Functionality here
    }
    public void ChangeHidePlayerNamesMode(bool left)
    {
        currentHPNSetting = ChangeSettingValue(currentHPNSetting,OnAndOffSettings,left);
        UpdateSections(HPNSliderSections,currentHPNSetting);
        HPNText.SetText(OnAndOffSettings[currentHPNSetting]);
        // add changing Hide other player names Functionality here
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

