using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContMovement : MonoBehaviour
{
    public XRNode inputSource;
    public float Speed = 1;
    private Vector2 inputAxis;
    private CharacterController chara;
    // Start is called before the first frame update
    void Start()
    {
        chara = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);

        chara.Move(direction * Time.fixedDeltaTime * Speed);
    }
}
