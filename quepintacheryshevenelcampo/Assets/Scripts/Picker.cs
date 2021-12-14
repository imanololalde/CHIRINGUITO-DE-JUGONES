using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{

    private Renderer pickerRenderer;

    private Pickable overPickable;
    private Pickable pickedObject;

    private void Awake()
    {
        pickerRenderer = GetComponentInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pickedObject != null)
        {
            return;
        }

        overPickable = other.GetComponent<Pickable>();

        if (overPickable != null)
        {
            pickerRenderer.material.color = Color.yellow;
        }
        else
        {
            pickerRenderer.material.color = Color.white;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickerRenderer.material.color = Color.white;
        overPickable = null;
    }

    public bool CanPick
    {
        get
        {
            return pickedObject == null && overPickable != null;
        }
    }

    public bool CanRelease
    {
        get
        {
            return pickedObject != null;
        }
    }

    public void Pick()
    {
        pickedObject = overPickable;
        pickerRenderer.enabled = false;

        pickedObject.Pick(this);
    }

    public void Release() {
        Release(Vector3.zero);
    }

    public void Release(Vector3 velocity)
    {
        pickedObject.Release();
        pickedObject.pickableRigidbody.velocity = velocity;

        pickedObject = null;
        pickerRenderer.enabled = true;
    }

}
