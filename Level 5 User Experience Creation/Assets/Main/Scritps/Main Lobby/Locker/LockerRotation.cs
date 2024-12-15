using UnityEngine;
using UnityEngine.EventSystems;

public class LockerRotation : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed;
    public Vector3 playerStartRotation;

    void Update()
    {
        if(Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject.name == "Player - Render texture")
        {
            // rotate the character based on mouse position
            float horizontal = rotationSpeed * Input.GetAxis("Mouse X");
            player.transform.Rotate(0,-horizontal,0);
        }
    }

    void OnDisable()
    {
        // when the locker screen is disabled return the player to their starting rotation
        player.transform.eulerAngles = playerStartRotation;
    }

}
