using UnityEngine;

[CreateAssetMenu(fileName = "Career", menuName = "ScriptableObjects/CareerList")]
public class CareerScriptable : ScriptableObject
{
    public PlayerCard[] playerCards;
}

[System.Serializable]
public class PlayerCard
{
    public string playerName;
}
