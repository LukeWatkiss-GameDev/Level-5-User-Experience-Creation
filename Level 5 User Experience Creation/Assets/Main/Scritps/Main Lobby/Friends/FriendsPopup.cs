using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FriendsPopup : MonoBehaviour
{
    private MainLobbyButtons mainLobbyButtonsScript;
    public GameObject selectedPlayer;
    public GameObject popupPanel;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var selectedOBJ =  EventSystem.current.currentSelectedGameObject;
            // check if the selected object is = null to avoid errors
            if(selectedOBJ != null &&selectedOBJ.CompareTag("FriendButton"))
            {
                // change the selected player to the object that was just clicked if it was tagged with "FriendButton"
                selectedPlayer = selectedOBJ;
                // take the name from the friend button object and add it to the popup
                popupPanel.transform.Find("Name").GetComponent<TMP_Text>().SetText(selectedOBJ.transform.Find("Name").GetComponent<TMP_Text>().text);
                // move the position of the popup
                popupPanel.transform.parent.position = selectedOBJ.transform.Find("Popup Holder").transform.position;
                // set the popup to active
                popupPanel.SetActive(true);
            }
        }
    }

    public void RemovePlayer()
    {
        // destroy the selected player object and remove the popup
        Destroy(selectedPlayer);
        popupPanel.SetActive(false);
    }

    public void MutePlayer()
    {
        
    }

    public void SendPlayerInvite()
    {
         
    }
}
