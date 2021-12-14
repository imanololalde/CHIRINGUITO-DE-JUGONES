using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.XR;

public class DevicePickerInput : MonoBehaviour
{

    private Picker picker;

    private TrackedPoseDriver poseDriver;

    private InputDevice device;

    private void Awake()
    {
        picker = GetComponent<Picker>();
        poseDriver = GetComponent<TrackedPoseDriver>();
    }

    private void UpdateDevice()
    {
        var side = poseDriver.poseSource == TrackedPoseDriver.TrackedPose.RightPose ? InputDeviceCharacteristics.Right : InputDeviceCharacteristics.Left;

        var devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(side | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller, devices);

        device = devices.FirstOrDefault(); //System.Linq
    }

    private void Update()
    {
        UpdateDevice();

        if (!device.isValid)
        {
            return;
        }

        device.TryGetFeatureValue(CommonUsages.grip, out float gripValue);

        bool pick = gripValue > .2f;
        bool release = gripValue < .1f;

        if (picker.CanRelease && release)
        {
            device.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
            picker.Release(velocity * 4f);
        }

        if (picker.CanPick && pick)
        {
            picker.Pick();
        }
    }

}
