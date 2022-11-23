using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6_3 : MonoBehaviour
{
  public List<Vector3> positions = new List<Vector3>();

  public float speed;
  private bool isMoving;  

  private int direction = 1;
  private int nextPosition = 0;

  void Start()
  {
    positions.Insert(0, transform.position);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.transform.parent = transform;
      
      isMoving = true;
    }
  }

  void FixedUpdate()
  {
    if (isMoving == true && transform.position == positions[nextPosition])
    {
      if (nextPosition == 0)
      {
        isMoving = false;
        direction = 1;
      }

      if (nextPosition + 1 == positions.Count)
      {
        isMoving = false;
        direction = -1;
      }

      nextPosition += direction;
    }

    if (isMoving == true)
    {
      transform.position = Vector3.MoveTowards(transform.position, positions[nextPosition], speed * Time.deltaTime);
    }
  }


  private void OnTriggerExit(Collider other)
  {
    other.transform.parent = null;
  }
}
