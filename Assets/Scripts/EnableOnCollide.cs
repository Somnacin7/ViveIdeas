using UnityEngine;
using System.Collections;

public class EnableOnCollide : MonoBehaviour
{

    public GameObject target;
    public bool enableOnCollide = true; // true: enable on collide, false: disable on collide
    // Use this for initialization
    void Start()
    {
        target.SetActive(!enableOnCollide);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        target.SetActive(enableOnCollide);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        target.SetActive(!enableOnCollide);
    }
}
