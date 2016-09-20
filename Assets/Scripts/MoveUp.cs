using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {

    public float speed = 10;

	// Use this for initialization
	void Start () {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
