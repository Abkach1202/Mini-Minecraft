using System;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
  // The mouse sensitivity
  [SerializeField] private float CameraMouseSensitivity;

  void FixedUpdate()
  {
    // Directional and mouse input
    float MouseInputY = -Input.GetAxis("Mouse Y") * CameraMouseSensitivity * Time.deltaTime;
    float AngleX = transform.localEulerAngles.x;

    // Rotating the camera
    AngleX = Math.Clamp(AngleX + MouseInputY, 0f, 90f);
    transform.localEulerAngles = new Vector3(AngleX, transform.localEulerAngles.y, transform.localEulerAngles.z);

  }
}
