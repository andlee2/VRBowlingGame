using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{   
    public Pin[] pins = new Pin[6];
    public GameObject ball;
    private InputDevice targetDevice;
    // Start is called before the first frame update
    Vector3 startingPosition = new Vector3(0,0.269f,1.111f);
    Vector3 startingVelocity = new Vector3(0,0,0);
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue) {
         
            ball.transform.position = startingPosition;
            ball.GetComponent<Rigidbody>().velocity = startingVelocity;
            ball.GetComponent<Rigidbody>().angularVelocity = startingVelocity;
            
        }

        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue) {
            foreach (var pin in pins)
            {
                pin.transform.position = pin.startingPosition;
                pin.transform.rotation = Quaternion.identity;
                pin.GetComponent<Rigidbody>().velocity = startingVelocity;
                pin.GetComponent<Rigidbody>().angularVelocity = startingVelocity;
                pin.pinKnockedDown = false;


            }
            
        }
    }
}
