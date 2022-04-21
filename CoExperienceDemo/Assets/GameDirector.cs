using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameDirector : MonoBehaviour
{
    GameObject ovrCameraRig;
    Transform centerEyeAnchor;
    Vector3 currentHeadDirection;
    LineRenderer lineRenderer;

    private void Start()
    {
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = ovrCameraRig.transform.GetChild(0).GetChild(1);
        lineRenderer=GetComponent<LineRenderer>();
    }

    private void Update()
    {
        currentHeadDirection = (centerEyeAnchor.rotation*Vector3.forward).normalized;
        Debug.Log("--" + currentHeadDirection);
        Ray ray = new Ray(new Vector3(0, 0, 0), currentHeadDirection);
        RaycastHit hit;
        Physics.Raycast(ray, out hit,Mathf.Infinity);
        lineRenderer.SetPosition(1, new Vector3(0,0,20));
        Debug.Log("point--" + hit.point);
        
        
    }

}
