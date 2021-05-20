using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private Animator animator;
    public string buttonName;

    private GrabbableObject hoveredObject;
    private GrabbableObject grabbedObject;


    private void OnTriggerEnter(Collider other)
    {
        GrabbableObject grabble = other.GetComponent<GrabbableObject>();

        if (grabble != null)
        {
            hoveredObject = grabble;
            hoveredObject.OnHoverStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GrabbableObject grabble = other.GetComponent<GrabbableObject>();

        if (grabble != null)
        {
            hoveredObject.OnHoverEnd();
            hoveredObject = null;

        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check if the grip button was pressed
        if (Input.GetButtonDown(buttonName))
        {
            animator.SetBool("Gripped", true);

            if (hoveredObject != null)
            {
                hoveredObject.OnGrabStart(this);

                grabbedObject = hoveredObject;
                hoveredObject = null;
            }

        }

        //check if the grip button was released
        if (Input.GetButtonUp(buttonName))
        {
            animator.SetBool("Gripped", false);

            if (grabbedObject != null)
            {
                grabbedObject.OnGrabEnd();
                grabbedObject = null;
            }

        }
    }
}
