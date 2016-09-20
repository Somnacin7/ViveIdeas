using UnityEngine;
using System.Collections;

public class ChangeShaderOnPoint : MonoBehaviour, Pointable {

    private Material material;
    public Material highlightMaterial;

    private bool isSelected;

	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerEnter()
    {
        isSelected = true;
        GetComponent<Renderer>().material = highlightMaterial;
    }

    public void OnPointerStay()
    {

    }

    public void OnPointerExit()
    {
        GetComponent<Renderer>().material = material;
    }
}
