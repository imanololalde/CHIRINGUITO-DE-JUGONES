using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EditorCamera : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - mouseY, transform.rotation.eulerAngles.y + mouseX, 0);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime);

        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.HeadMounted, devices);

        if (devices.Count == 0)
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                1.7f,
                transform.localPosition.z
            );
        }
    }

}
