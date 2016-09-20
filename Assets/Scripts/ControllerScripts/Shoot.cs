using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedController))]
public class Shoot : MonoBehaviour {

    public Transform bullet;
    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {
        var trackedController = GetComponent<SteamVR_TrackedController>();

        trackedController.TriggerClicked += new ClickedEventHandler(DoTriggerClick);
	}
	
	void DoTriggerClick(object sender, ClickedEventArgs e)
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}