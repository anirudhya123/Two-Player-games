using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GlassMovement : MonoBehaviour
{

    

    private void Start()
    {
        
        transform.DOMoveX(0f, 1.5f).SetEase(Ease.OutExpo).SetLoops(-1,LoopType.Yoyo);
    }
}
