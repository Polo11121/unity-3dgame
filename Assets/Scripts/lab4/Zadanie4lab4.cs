using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie4lab4 : MonoBehaviour
{

  public Transform player;
  public float sensitivity;
  private float mouseX;
  private float mouseY;
  private float xRotation;
  bool lockX;

  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {
    mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
    mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

    player.Rotate(Vector3.up * mouseX);

    xRotation -= mouseY;

    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.Rotate(new Vector3(-mouseY, 0f, 0f), Space.Self);
    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
  }
}
