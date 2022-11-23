using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6_1 : MonoBehaviour
{
  public Vector3 target;
  private Vector3 targetPosition;
  private List<Vector3> positions = new List<Vector3>();

  public float speed;
  private bool isMoving;

  void Start()
  {
    positions.Add(transform.position);
    positions.Add(target);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.transform.parent = transform;
      
      if (transform.position == positions[0])
      {
        targetPosition = positions[1];
      }
      else if (transform.position == positions[1])
      {
        targetPosition = positions[0];
      }

      isMoving = true;
    }
  }

  void FixedUpdate()
  {
    if (isMoving == true && transform.position == targetPosition)
    {
      targetPosition = positions[0];
    }

    if (isMoving == true)
    {
      transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
  }



  private void OnTriggerExit(Collider other)
  {
    other.transform.parent = null;
  }
}
