using System;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
  // The mouse sensitivity
  [SerializeField] private float CameraMouseSensitivity;
  // The player input
  [SerializeField] private PlayerInput PlayerInput;

  // FixedUpdate is called once per frame
  void FixedUpdate()
  {
    // Directional and mouse input
    float MouseInputY = -PlayerInput.GetMouseY() * CameraMouseSensitivity * Time.deltaTime;
    float AngleX = transform.localEulerAngles.x;

    // Rotating the camera
    AngleX = Math.Clamp(AngleX + MouseInputY, 0f, 90f);
    transform.localEulerAngles = new Vector3(AngleX, transform.localEulerAngles.y, transform.localEulerAngles.z);
  }
}
