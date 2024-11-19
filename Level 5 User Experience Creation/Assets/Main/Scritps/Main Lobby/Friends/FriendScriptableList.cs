using UnityEngine;

[CreateAssetMenu(fileName = "Friends", menuName = "ScriptableObjects/friendList")]
public class FriendScriptableList : ScriptableObject
{
    public Friend[] listOfFriends;

}

[System.Serializable]
public class Friend
{
    public string playerName;
    public string playerStatus;
}
