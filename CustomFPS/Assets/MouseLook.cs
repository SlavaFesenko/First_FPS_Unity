using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensivityHor = 9.0f;
    public float sensivityVert = 9.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;


    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            this.transform.Rotate(0, Input.GetAxis("Mouse X")*sensivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;

            this.transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            this.transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        
    }
}
