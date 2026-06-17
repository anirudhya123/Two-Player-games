using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Swiping : MonoBehaviour
{
    public GameObject scrollbar;
    public Vector2 scaleOffset;
    float  scrollPos = 0;
    float[] pos;
    public AudioClip track;
    AudioManager audioManager;
    public TextMeshProUGUI textMeshProUGUI;
    int active = 0;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0;i < pos.Length;i++)
            {
                if(scrollPos < pos[i] + (distance/2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);

                }
            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
            {

                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, scaleOffset, 0.1f);
                Changed(active, i);
                active = i;
                

                for (int j = 0; j < pos.Length; j++)
                {
                    if(j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.5f, 0.5f), 0.1f);
                    }
                }

            }

        }

        textMeshProUGUI.text = transform.GetChild(active).name;
    }

    void Changed(int act, int curr)
    {
        if (act != curr) audioManager.PlayParticular(track);
    }
}
