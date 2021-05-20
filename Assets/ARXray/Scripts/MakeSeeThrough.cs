using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSeeThrough : MonoBehaviour
{
    void Start()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002; //set renderQueue to render after our Invisible mask(3001)
        }

    }
}
