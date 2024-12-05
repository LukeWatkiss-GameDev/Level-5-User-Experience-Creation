using UnityEngine;

public class LockerCosmetics : MonoBehaviour
{
    public LockerMenu lockerMenuScript;
    public GameObject[] Character,Hair,Eyes,Gloves,Mouth,Misc;

    // these functions are all called from individual buttons 
    // when a button is pressed they pass in an index to use that checks throught the array of items 
    // and sets the item at the given index to true

    // this may change in the future to make it look better but i currently have no idea how i would do that (04/12/2024)
    public void ChangeCharacter(int index)
    {
        foreach (var item in Character)
        {
            if(item == Character[index])
            {
                item.SetActive(true);
                lockerMenuScript.ChangePanelSprite(lockerMenuScript.character,lockerMenuScript.characterSprites[index]);
            }
            else 
            {
                item.SetActive(false);
            }
        }
    }    
    public void ChangeHair(int index)
    {
        foreach (var item in Hair)
        {
            if(item == Hair[index])
            {
                item.SetActive(true);
                lockerMenuScript.ChangePanelSprite(lockerMenuScript.hair,lockerMenuScript.hairSprites[index]);
            }
            else 
            {
                item.SetActive(false);
            }
        }
    }    

    public void ChangeEyes(int index)
    {
        foreach (var item in Eyes)
        {
            if(item == Eyes[index])
            {
                item.SetActive(true);
                lockerMenuScript.ChangePanelSprite(lockerMenuScript.eyes,lockerMenuScript.eyeSprites[index]);
            }
            else 
            {
                item.SetActive(false);
            }
        }
    }    

    public void ChangeGloves(int index)
    {
        foreach (var item in Gloves)
        {
            if(item == Gloves[index])
            {
                item.SetActive(true);
                lockerMenuScript.ChangePanelSprite(lockerMenuScript.gloves,lockerMenuScript.glovesSprites[index]);
            }
            else 
            {
                item.SetActive(false);
            }
        }
    }    

    public void ChangeMouth(int index)
    {
        foreach (var item in Mouth)
        {
            if(item == Mouth[index])
            {
                item.SetActive(true);
                lockerMenuScript.ChangePanelSprite(lockerMenuScript.mouth,lockerMenuScript.mouthSprites[index]);
            }
            else 
            {
                item.SetActive(false);
            }
        }
    }    

    public void ChangeMisc(int index)
    {
        foreach (var item in Misc)
        {
            if(item == Misc[index])
            {
                item.SetActive(true);
                lockerMenuScript.ChangePanelSprite(lockerMenuScript.misc,lockerMenuScript.miscSprites[index]);
            }
            else 
            {
                item.SetActive(false);
            }
        }
    }    

}
