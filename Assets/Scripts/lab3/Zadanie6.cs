using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie6 : MonoBehaviour
{

  public Transform target;
  public float smoothTime = 0f;
  public float Velocity = 1f;

  void Update()
  {
    float newPositionZ = Mathf.SmoothDamp(transform.position.z, target.position.z, ref Velocity, smoothTime);
    float newPositionX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref Velocity, smoothTime);
    
    transform.position = new Vector3(newPositionX, transform.position.y, newPositionZ);
  }
}
