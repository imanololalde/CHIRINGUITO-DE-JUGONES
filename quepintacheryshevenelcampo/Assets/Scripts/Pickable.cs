using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    private Transform originalParent;

    public Rigidbody pickableRigidbody;

    private void Awake()
    {
        pickableRigidbody = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    public void Pick(Picker picker)
    {
        transform.SetParent(picker.transform);
        pickableRigidbody.isKinematic = true;
    }

    public void Release()
    {
        transform.SetParent(originalParent);
        pickableRigidbody.isKinematic = false;
    }

}
