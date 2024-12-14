using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamemodeManager : MonoBehaviour
{
    public Image mainSelectModeImage;
    MainLobbyButtons mainLobbyButtonsScript;

    void Start()
    {
        mainLobbyButtonsScript = transform.root.GetComponent<MainLobbyButtons>();
    }

    public void ChangeGamemodeSprite()
    {
        //change the sprite 
        Sprite spriteToChangeTo = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        mainSelectModeImage.sprite = spriteToChangeTo;
        // close modal
        mainLobbyButtonsScript.backgroundDarken.SetActive(false);
        mainLobbyButtonsScript.CloseModal(true);
    }

}
