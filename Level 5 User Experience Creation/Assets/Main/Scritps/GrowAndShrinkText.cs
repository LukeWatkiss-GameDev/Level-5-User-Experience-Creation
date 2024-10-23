using UnityEngine;
using DG.Tweening;


public class GrowAndShrinkText : MonoBehaviour
{
    GameObject OBJ;
    public float maxScaleSizeText;
    [Header("Bools")]
    public bool text;
    public bool panel;

    void OnEnable()
    {
        OBJ = this.gameObject;
        
        if(text)
        {
            
            TextGrow();
        }

        if(panel)
        {
            panelGrow();
        }
    }

    void OnDisable()
    {
        if(text)
        {
            DOTween.Kill(transform); // Stops all dotween animations on this transfrom/Gameobject
        }
    }

    void TextGrow() //grow text from scale (0,0,0) to (1,1,1)
    {
        OBJ.transform.localScale = Vector3.zero;
        OBJ.transform.DOScale(1,1).SetEase(Ease.InOutSine).OnComplete(()=> TextGrowAndShrink());
    }

    void TextGrowAndShrink() // grow and shrink text indefinetly 
    {
        OBJ.transform.localScale = new Vector3(1,1,1);
        OBJ.transform.DOScale(maxScaleSizeText,1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    void panelGrow() // scale a panel from (0,0,0) to (1,1,1)
    {
        OBJ.transform.localScale = Vector3.zero;
        OBJ.transform.DOScale(new Vector3(1,1,1),1).SetEase(Ease.InOutSine);
    }

    public void panelShrink() //scale a panel from (1,1,1) to (0,0,0)
    {
        
        OBJ.transform.DOScale(0,1).SetEase(Ease.InOutSine).OnComplete(()=> OBJ.transform.parent.gameObject.SetActive(false));
    }


}
