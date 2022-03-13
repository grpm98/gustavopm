using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] GameObject uiCanvas;

    // Update is called once per frame
    private void Start()
    {
        camara = Camera.main;
        StartCoroutine(LookAtTransform());
    }

    IEnumerator LookAtTransform()
    {
        uiCanvas.transform.LookAt(camara.transform);
        yield return null;
    }
}
