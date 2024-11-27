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
            if(selectedOBJ.CompareTag("FriendButton"))
            {
                selectedPlayer = selectedOBJ;
                popupPanel.transform.Find("Name").GetComponent<TMP_Text>().SetText(selectedOBJ.transform.Find("Name").GetComponent<TMP_Text>().text);
                popupPanel.transform.parent.position = selectedOBJ.transform.Find("Popup Holder").transform.position;
                popupPanel.SetActive(true);
            }
        }
    }

    public void RemovePlayer()
    {
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
