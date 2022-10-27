using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{

  public float speed;
  private Vector3 direction;

  void Update()
  {   
    if (transform.position.z >= 10)
    {
      direction = new Vector3(0, 0, 0);
    }
    
    if (transform.position.z <= 0)
    {
      direction = new Vector3(0, 0, 10);
    }

    transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
  }
}