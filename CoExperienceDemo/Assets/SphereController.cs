using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SphereController : MonoBehaviour
{

    GameObject ovrCameraRig;
    Transform centerEyeAnchor;
    Vector3 preHeadRotation;
    Vector3 currentHeadRotation;
    Vector3 deltaHeadRotation;
    public float rotationGain = 0.5f;


    private void Start()
    {
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = ovrCameraRig.transform.GetChild(0).GetChild(1);
        preHeadRotation = centerEyeAnchor.eulerAngles;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

    }

    private void Update()
    {
        currentHeadRotation = centerEyeAnchor.eulerAngles;
        //deltaHeadRotation = currentHeadRotation - preHeadRotation;
        if (currentHeadRotation.y - preHeadRotation.y > 300)
        {
            deltaHeadRotation = currentHeadRotation - preHeadRotation - new Vector3(0, 360, 0);
        }
        else if (currentHeadRotation.y - preHeadRotation.y < -300)
        {
            deltaHeadRotation = currentHeadRotation - preHeadRotation + new Vector3(0, 360, 0);
        }
        else { deltaHeadRotation = currentHeadRotation - preHeadRotation; }
        Vector3 rotationGainAngles = (rotationGain-1) * new Vector3(0, deltaHeadRotation.y, 0);
        this.transform.Rotate(-rotationGainAngles);
        preHeadRotation = currentHeadRotation;

    }
}
