using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleText : MonoBehaviour
{
    AppleRelocator relocator;
    TextMeshProUGUI textMeshPro;

    private void Start()
    {
        relocator = FindObjectOfType<AppleRelocator>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if(gameObject.name == "Red")
            textMeshPro.text = relocator.redScore.ToString();
        else
            textMeshPro.text = relocator.greenScore.ToString();
    }
}
