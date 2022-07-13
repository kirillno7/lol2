using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform PlayerBody;
    [SerializeField] float Sensitivity = 1;
    float Yrot = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xRot = Input.GetAxis("Mouse X");
        var yRot = Input.GetAxis("Mouse Y");
        Yrot -= yRot;
        var Yocon = Yrot * Sensitivity;
        Yocon = Mathf.Clamp(Yocon, -80, 70);
        PlayerBody.Rotate(new Vector3(0,xRot*Sensitivity,0));
        transform.localRotation = Quaternion.Euler(Yocon,0,0);

    }
}
