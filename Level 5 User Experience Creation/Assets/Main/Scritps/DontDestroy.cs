using UnityEngine;

/*
* If an object has this attached it will not be destroyed when a new scene is loaded
*/
public class DontDestroy : MonoBehaviour
{

    [HideInInspector] public string objectID;

    private void Awake()
    {
        objectID = name + transform.position.ToString(); // allows multiple objects , that are called the same thing, to use this script
    }
    
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }

}