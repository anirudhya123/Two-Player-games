using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScale : MonoBehaviour
{
    [SerializeField] private float referenceHeight;
    [SerializeField] private float referenceWidth;
    [SerializeField] private Vector3 referenceScale;
    [SerializeField] Canvas canvas;

    private float deviceHeight;
    private float deviceWidth;

    private void Start()
    {
        if(gameObject.tag == "NonResponsive")
            transform.localScale =  AdjustedBackgroundScale();
        else
            transform.localScale = AdjustedOthersScale();

    }

    Vector3 AdjustedBackgroundScale()
    {
        RectTransform rectTransform = canvas.GetComponent<RectTransform>();
        deviceHeight = rectTransform.sizeDelta.y;
        deviceWidth = rectTransform.sizeDelta.x;
        float deviceArea = deviceHeight * deviceWidth;

        float referenceArea = referenceHeight * referenceWidth;
        float referenceRatioX = referenceScale.x / referenceWidth;
        float referenceRatioY = referenceScale.y / referenceHeight;
        float referenceRatioZ = referenceScale.z / referenceArea;

        float deviceScaleX = deviceWidth * referenceRatioX;
        float deviceScaleY = deviceHeight * referenceRatioY;
        float deviceScaleZ = deviceArea * referenceRatioZ;

        Vector3 adjustedScale = new Vector3(deviceScaleX, deviceScaleY, deviceScaleZ);

        return adjustedScale;
    }
    Vector3 AdjustedOthersScale()
    {
        RectTransform rectTransform = canvas.GetComponent<RectTransform>();
        deviceWidth = rectTransform.sizeDelta.x;

        float referenceRatio = referenceScale.x / referenceWidth;

        float deviceScale = deviceWidth * referenceRatio;

        Vector3 adjustedScale = new Vector3(deviceScale, deviceScale, deviceScale);

        return adjustedScale;
    }
}
