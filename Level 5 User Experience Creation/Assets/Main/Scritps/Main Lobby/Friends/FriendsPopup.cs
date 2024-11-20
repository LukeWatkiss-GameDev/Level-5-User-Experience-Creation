using UnityEngine;
using UnityEngine.EventSystems;

public class FriendsPopup : MonoBehaviour
{
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
                popupPanel.SetActive(true);
            }
        }
    }

    public void RemovePlayer()
    {
        Destroy(selectedPlayer);
        popupPanel.SetActive(true);
    }
}
