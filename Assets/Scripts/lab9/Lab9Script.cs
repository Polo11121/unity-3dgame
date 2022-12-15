using UnityEngine;

public class Lab9Script: MonoBehaviour {
  private Transform currentPoint;
  private Transform nextPoint;
  private GameObject player;

  public Transform pointA;
  public Transform pointB;

  private bool isVisible = false;
  private bool isOutOfRange = true;

  public float walkSpeed = 3f;
  public float runSpeed = 4f;

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    currentPoint = pointB;
    nextPoint = pointA;
  }

  private void CheckIfInRange() {
    if (player.transform.position.x < pointA.transform.position.x || player.transform.position.x > pointB.transform.position.x) {
      isOutOfRange = true;
    } else {
      isOutOfRange = false;
    }
  }

  private void Update() {
    CheckIfInRange();

    if (!isOutOfRange && isVisible) {
      Vector3 newPosition = new Vector3(player.transform.position.x, transform.position.y, 0f);
      transform.position = Vector3.MoveTowards(transform.position, newPosition, runSpeed * Time.deltaTime);
    } else if (transform.position == currentPoint.transform.position) {
      Transform temp = currentPoint;
      currentPoint = nextPoint;
      nextPoint = temp;
    } else {
      transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, walkSpeed * Time.deltaTime);
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (!isOutOfRange && isVisible) {
      if (Vector3.Distance(pointA.transform.position, other.transform.position) < Vector3.Distance(pointB.transform.position, other.transform.position)) {
        currentPoint = pointA;
        nextPoint = pointB;
      } else {
        currentPoint = pointB;
        nextPoint = pointA;
      }
    }

    if (other.CompareTag("Player")) {
      isVisible = true;
      CheckIfInRange();
    }

  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      isVisible = false;
    }
  }
}