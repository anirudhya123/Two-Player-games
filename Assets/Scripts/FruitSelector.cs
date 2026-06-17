using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSelector : MonoBehaviour
{
    private void Start()
    {
        int activationCode = Random.Range(0,transform.childCount);
        transform.GetChild(activationCode).gameObject.SetActive(true);
    }

}
