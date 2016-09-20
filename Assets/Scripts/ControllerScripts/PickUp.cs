using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUp : MonoBehaviour
{
    public Rigidbody attachPoint;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    FixedJoint fixedJoint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int) trackedObj.index);
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay");
        if (fixedJoint == null && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            fixedJoint = col.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = attachPoint;
        }
        else if (fixedJoint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            destroyFixedJoint();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (fixedJoint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            destroyFixedJoint();
        }
    }

    void destroyFixedJoint()
    {
        var go = fixedJoint.gameObject;
        var rb = go.GetComponent<Rigidbody>();
        Destroy(fixedJoint);
        fixedJoint = null;
        tossObject(rb);
    }

    void tossObject(Rigidbody rb)
    {
        Transform origin = trackedObj.origin ?? trackedObj.transform.parent;
        if (origin != null)
        {
            rb.velocity = origin.TransformVector(device.velocity);
            rb.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else
        {
            rb.velocity = device.velocity;
            rb.angularVelocity = device.angularVelocity;
        }
    }

}
