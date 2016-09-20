using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedController))]
public class Pointer : MonoBehaviour
{
    public float pointerRange = 10;

    private GameObject savedHit;

    // Use this for initialization
    void Start()
    {
        var trackedController = GetComponent<SteamVR_TrackedController>();
        trackedController.TriggerClicked += OnTriggerClicked;

    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.gameObject == savedHit)
            {
                var pointable = hit.transform.gameObject.GetComponent<Pointable>();
                if (pointable != null)
                {
                    pointable.OnPointerStay();
                }
            }
            else
            {
                if (savedHit != null)
                {
                    var savedPointable = savedHit.GetComponent<Pointable>();
                    if (savedPointable != null)
                    {
                        savedPointable.OnPointerExit();
                    }
                }
                var pointable = hit.transform.gameObject.GetComponent<Pointable>();
                if (pointable != null)
                {
                    pointable.OnPointerEnter();
                }
            }
            savedHit = hit.transform.gameObject;
        }
        else
        {
            if (savedHit != null)
            {
                var savedPointable = savedHit.GetComponent<Pointable>();
                if (savedPointable != null)
                {
                    savedPointable.OnPointerExit();
                }
            }
            savedHit = null;
        }


    }

    void OnTriggerClicked(object sender, ClickedEventArgs e)
    {

    }
}
