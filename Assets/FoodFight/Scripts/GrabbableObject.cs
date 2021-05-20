using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{

    private Material material;
    private Color originalColor;

    public Color hoveredColor;


    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }


    public void OnHoverStart()
    {
        material.color = hoveredColor;
    }

    public void OnHoverEnd()
    {
        material.color = originalColor;
    }

    public void OnGrabStart(Grabber hand)
    {
        transform.SetParent(hand.transform);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnGrabEnd()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
