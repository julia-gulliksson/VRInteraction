using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMaskLayer : MonoBehaviour
{
    [SerializeField] LayerMask Interactor;
    [SerializeField] LayerMask Interactable;
    void Start()
    {
        StartCoroutine(TestLayer());
    }

    IEnumerator TestLayer()
    {
        string interactionMessage = "";
        while (true)
        {
            LayerMask result = Interactor & Interactable;
            if (result.value != 0)
            {
                interactionMessage = " has interaction";
            }
            else
            {
                interactionMessage = "no interaction";
            }
            Debug.Log("Interactable : " + Interactable.value);
            Debug.Log("Interactor : " + Interactor.value);
            Debug.Log("Combined : " + result.value);
            Debug.Log(interactionMessage);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
