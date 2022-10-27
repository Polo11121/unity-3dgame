using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{

  public GameObject cube;
  public List<Vector3> positions;
  private Vector3 newPosition;

  void Start()
  {
    int x;
    int z;

    for (int i = 1; i <= 10; i++)
    {
      x = Random.Range(6, 14);
      z = Random.Range(6, 14);

      newPosition = new Vector3(x, transform.position.y+5, z);

      while (positions.Contains(new Vector3(x, transform.position.y+5, z)))
      {
        x = Random.Range(6, 14);
        z = Random.Range(6, 14);
        newPosition = new Vector3(x, transform.position.y+5, z);
      }
      
      positions.Add(newPosition);
      Instantiate(cube, newPosition, Quaternion.identity);
    }
  }
}
