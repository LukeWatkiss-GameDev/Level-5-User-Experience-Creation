using UnityEngine;
using UnityEngine.UI;

public class LockerMenu : MonoBehaviour
{

    public GameObject[] lockerPanels;
    public GameObject lockerPopup;
    public Image character,hair,eyes,gloves,mouth,misc;
    
    // yet another big array of sprites as i can't think of another way around this
    public Sprite[] characterSprites,hairSprites,eyeSprites,glovesSprites,mouthSprites,miscSprites;

    public void ChangePanel(int index)
    {
        // swap between panels with a given index 
        // this will be called from the buttons on the locker screen
        foreach (var item in lockerPanels)
        {
            if(item == lockerPanels[index])
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
            
        }

        lockerPopup.SetActive(true);
    }

    public void ChangePanelSprite(Image image,Sprite sprite)
    {
        image.sprite = sprite; 
        // this line fixes the stretching of sprites however also makes some sprites stick out when setting native size
        // especially on the gloves
        // without this some item sprites are stretched
        if(image != gloves || image != character)
        {
            image.SetNativeSize(); 

        }
    }
}
