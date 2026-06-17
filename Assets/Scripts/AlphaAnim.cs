using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class AlphaAnim : MonoBehaviour
{
    private void Start()
    {
        if(transform.GetComponent<SpriteRenderer>() != null) 
            transform.GetComponent<SpriteRenderer>().DOFade(.1f,1f).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);
        else if(transform.GetComponent<TextMeshProUGUI>() != null)
            transform.GetComponent<TextMeshProUGUI>().DOFade(.1f, 1f).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);
        else
            transform.GetComponent<Image>().DOFade(.1f, 1f).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);
    }
}
