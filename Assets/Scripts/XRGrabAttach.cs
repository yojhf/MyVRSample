using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRGrabAttach : XRGrabInteractable
{
    public Transform attach_R;
    public Transform attach_L;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = attach_L;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = attach_R;
        }

     
        base.OnSelectEntered(args);
    }
}
