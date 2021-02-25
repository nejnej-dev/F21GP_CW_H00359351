using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;

    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;

    void LateUpdate()
    {
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = targetObject.TransformPoint(cameraOffset);
        }
        else
        {
            transform.position = targetObject.position + cameraOffset;
        }

        if (lookAt)
        {
            transform.LookAt(targetObject);
        }
        else
        {
            transform.rotation = targetObject.rotation;
        }
    }
}
