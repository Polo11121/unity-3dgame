using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie4 : MonoBehaviour
{
  public float speed;

  void Update()
  {
    float horizontalMovement = Input.GetAxis("Horizontal");
    float verticalMovement = Input.GetAxis("Vertical");

    transform.Translate(new Vector3(horizontalMovement * speed * Time.deltaTime, 0, 0));
    transform.Translate(new Vector3(0, 0, verticalMovement * speed * Time.deltaTime));
  }
}
