using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;


    public void FadeToLevel()
    {
        // set the animator parameter "Fade Out" to true
        animator.SetTrigger("Fade Out");
    }
}
