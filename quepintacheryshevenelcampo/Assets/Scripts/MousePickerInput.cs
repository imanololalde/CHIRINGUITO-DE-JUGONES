using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickerInput : MonoBehaviour
{

    private Picker picker;

    private void Awake()
    {
        picker = GetComponent<Picker>();
    }

    private void Update()
    {
        if (picker.CanRelease && Input.GetMouseButtonDown(0))
        {
            picker.Release(Camera.main.transform.forward * 10);
        }

        if (picker.CanPick && Input.GetMouseButtonDown(0))
        {
            picker.Pick();
        }
    }

}
