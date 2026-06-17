using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFolder : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject panel;
    [SerializeField] RectTransform title;
    [SerializeField] RectTransform body;
    [SerializeField] EventManager events;


    private void Start()
    {
        Open();
    }
    public void Open()
    {
        panel.SetActive(true);
        //canvasGroup.alpha = 0;
        title.localPosition = new Vector3(0, 1000f, 0);
        body.localPosition = new Vector3(0, -1601f, 0);
        title.DOAnchorPos(new Vector2(0f, 637f), 1f, false).SetEase(Ease.OutElastic).OnComplete(() =>
        {
            body.DOAnchorPos(new Vector2(0f, 486f), 1f, false).SetEase(Ease.OutElastic);
        });
        //canvasGroup.DOFade(1, 1f);

    }
    public void Close()
    {
        //canvasGroup.alpha = 1;
        title.localPosition = new Vector3(0, 637, 0);
        body.localPosition = new Vector3(0, 486, 0);
        title.DOAnchorPos(new Vector2(0f, 1000f), 1f, false).SetEase(Ease.InOutQuint);
        body.DOAnchorPos(new Vector2(0, -2601f), 1f, false).SetEase(Ease.InOutQuint);
                canvasGroup.DOFade(0, 1f).OnComplete(() =>
                {
                    panel.SetActive(false);
                    events.RestartApple();
                });

            
        
    }
}
