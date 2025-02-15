using UnityEngine;
using DG.Tweening;

public class GrowAndShrinkText : MonoBehaviour
{

    public float maxScaleSizeText;
    [Header("Bools")]
    public bool text;
    public bool panel;

    void OnEnable()
    {   
        if(text)
        {
            TextGrow();
        }
        if(panel)
        {
            PanelGrow();
        }
    }
    
    void OnDisable()
    {
        if(text)
        {
            DOTween.Kill(transform); // Stops all dotween animations on this transfrom/Gameobject
        }
    }
    #region Text
    void TextGrow() //grow text from scale (0,0,0) to (1,1,1)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1,1).SetEase(Ease.InOutSine).OnComplete(()=> TextGrowAndShrink());
    }

    void TextGrowAndShrink() // grow and shrink text indefinetly 
    {
        transform.localScale = new Vector3(1,1,1);
        transform.DOScale(maxScaleSizeText,1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    #endregion

    #region Panel
    void PanelGrow() // scale a panel from (0,0,0) to (1,1,1)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(new Vector3(1,1,1),.5f).SetEase(Ease.InOutSine);
    }

    public void PanelShrink() //scale a panel from (1,1,1) to (0,0,0) then set the object to inactive
    {
        
        transform.DOScale(0,.5f).SetEase(Ease.InOutSine).OnComplete(()=> transform.parent.gameObject.SetActive(false));
    }
    #endregion
}
