using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionRotacion : MonoBehaviour
{
    public float rotateSpeed = 360;

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }

}
