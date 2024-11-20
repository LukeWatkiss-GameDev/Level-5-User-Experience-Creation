using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendGenerator : MonoBehaviour
{
    FriendsPopup friendsPopupScript;
    List<int> friendsInUse = new List<int>();

    int friendsToGenerate;
    public TMP_Text amountOfFriendsText;

    FriendScriptableList friendScriptableList;

    public GameObject listParent;
    public GameObject friendPrefab;

    public Sprite Online,AFK,Offline,inGame;

    public float scrollAmount;


    // Start is called before the first frame update
    void Start()
    {
        friendsPopupScript = transform.parent.GetComponentInChildren<FriendsPopup>();

        friendScriptableList = Resources.Load<FriendScriptableList>("Friends");
        friendsToGenerate = Random.Range(8,friendScriptableList.listOfFriends.Length);
        
        for (int i = 0; i < friendsToGenerate; i++)
        {

            int randomInt = Random.Range(0,friendScriptableList.listOfFriends.Length);
            if(friendsInUse.Contains(randomInt))
            {
                i--;
            }
            else if(!friendsInUse.Contains(randomInt))
            {
                GenerateFriend(randomInt);
                friendsInUse.Add(randomInt);
            }
        }
        amountOfFriendsText.SetText("FRIENDS (" + friendsToGenerate+ "/" +friendScriptableList.listOfFriends.Length +")");
    }

    void GenerateFriend(int index)
    {
        // create new friend obj and parent to the grid content

        GameObject friend = Instantiate(friendPrefab,listParent.transform);
        
        Image curSprite = friend.GetComponent<Image>();
        string status = friendScriptableList.listOfFriends[index].playerStatus;
        // assign status and name from the list of names 
        friend.transform.Find("Name").GetComponent<TMP_Text>().SetText(friendScriptableList.listOfFriends[index].playerName);
        friend.transform.Find("Status").GetComponent<TMP_Text>().SetText(status);
        // change the sprite based on the status of the player
        if(status == "Online" || status == "In Lobby")
        {
            curSprite.sprite = Online;
        }
        else if(status == "AFK")
        {
            curSprite.sprite = AFK;
        }
        else if(status.Contains("Playing"))
        {
            curSprite.sprite = inGame;
        }
        else if(status == "Offline")
        {
            curSprite.sprite = Offline;
        }
    }

    // buttons for scrolling through the list
    public void ScrollDownList()
    {
        listParent.transform.position = new Vector3(listParent.transform.position.x,listParent.transform.position.y + scrollAmount,0);
    }

    public void ScrollUpList()
    {
        listParent.transform.position = new Vector3(listParent.transform.position.x,listParent.transform.position.y - scrollAmount,0);
    }
}
