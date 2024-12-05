using UnityEngine;
using UnityEngine.EventSystems;

public class LockerRotation : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed;
    Vector3 playerStartRotation;
    // Update is called once per frame

    void Start()
    {
        playerStartRotation = player.transform.eulerAngles;
 
    }
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
        player.transform.eulerAngles = playerStartRotation;
    }

}
