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
        Debug.Log(image);
        image.sprite = sprite; 
        // check if the image that will be change is not the gloves
        // this is because if the gloves are set to native size they go outside of the box
        // and dont need to be set to native as there is not streaching
        if(image != gloves)
        {
            Debug.Log("Set native");
            // this line fixes the stretching of sprites however also makes some sprites stick out when setting native size
            // without this some item sprites are stretched
            image.SetNativeSize(); 

        }
    }
}
