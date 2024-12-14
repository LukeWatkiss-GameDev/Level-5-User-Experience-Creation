using DG.Tweening;
using UnityEngine;

public class RPassRotate : MonoBehaviour
{
    public Vector3 rotateValue;
    public float rotateSpeed;
    void Start()
    {
        // rotate the items in a full circle
        transform.DOLocalRotate(rotateValue,rotateSpeed,RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

}
