using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Zadanie1 : MonoBehaviour
{
  List<Vector3> positions = new List<Vector3>();

  public List<int> position_x;
  public List<int> position_z;
  public List<Material> materials = new List<Material>();

  int objectCounter = 0;
  public float delay = 3.0f;
  public int objectAmount;
  
  public GameObject block;
  private Renderer render;

  void Start()
  {
    render = GetComponent<Renderer>();

    int boundX = Mathf.CeilToInt(render.bounds.extents.x);
    int boundZ = Mathf.CeilToInt(render.bounds.extents.z);

    int boundNegativeX = Mathf.CeilToInt(render.bounds.center.x - render.bounds.extents.x);
    int boundNegativeZ = Mathf.CeilToInt(render.bounds.center.z - render.bounds.extents.z);

    position_x = new List<int>(Enumerable.Range(boundNegativeX, boundX * 2).OrderBy(x => System.Guid.NewGuid()).Take(10));
    position_z = new List<int>(Enumerable.Range(boundNegativeZ, boundZ * 2).OrderBy(x => System.Guid.NewGuid()).Take(10));

    for (int i = 0; i < objectAmount; i++)
    {
      this.positions.Add(new Vector3(position_x[i], 5, position_z[i]));
    }

    StartCoroutine(GenerateObject());
  }

  IEnumerator GenerateObject()
  {
    foreach (Vector3 position in positions)
    {
      if (this.objectCounter != objectAmount)
      {
        GameObject clone = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
        clone.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count() - 1)];

        yield return new WaitForSeconds(this.delay);
      }
    }

    StopCoroutine(GenerateObject());
  }
}
