using UnityEngine;
using DG.Tweening;


public class GrowAndShrinkText : MonoBehaviour
{
    GameObject OBJ;
    public float maxScaleSizeText;
    public bool text;
    public bool panel;

    // Start is called before the first frame update
    void OnEnable()
    {
        OBJ = this.gameObject;
        
        if(text)
        {
            TextGAS();
        }

        if(panel)
        {
            panelGrow();
        }
    }

    void TextGAS() //grow and shrink text
    {
        
        OBJ.transform.DOScale(maxScaleSizeText,1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    void panelGrow()
    {
        OBJ.transform.localScale = Vector3.zero;
        OBJ.transform.DOScale(new Vector3(1,1,1),1).SetEase(Ease.InOutSine);
    }

    public void panelShrink()
    {
        
        OBJ.transform.DOScale(0,1).SetEase(Ease.InOutSine).OnComplete(()=> OBJ.transform.parent.gameObject.SetActive(false));
    }


}
