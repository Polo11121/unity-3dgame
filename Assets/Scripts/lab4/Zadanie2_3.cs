using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2_3 : MonoBehaviour
{
  private CharacterController controller;

  private Vector3 move;
  public Vector3 velocity;

  private bool groundedPlayer;
  private float moveX;
  private float moveZ;
  public float speed;

  public float gravity = -9.81f;
  public float jumpHeight = 5f;
  private float pushPower = 2.0f;

  void Start()
  {
    controller = gameObject.GetComponent<CharacterController>();
  }

  void Update()
  {

    moveX = Input.GetAxis("Horizontal");
    moveZ = Input.GetAxis("Vertical");

    groundedPlayer = controller.isGrounded;

    if (groundedPlayer && velocity.y < 0)
    {
      velocity.y = 0f;
    }

    move = transform.right * moveX + transform.forward * moveZ;
    controller.Move(move * Time.deltaTime * speed);

    if (Input.GetButton("Jump") && groundedPlayer)
    {
      velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);
  }

  private void onTriggerEnter(ControllerColliderHit hit)
  {
    Rigidbody body = hit.collider.attachedRigidbody;

    if (body == null || body.isKinematic)
    {
      return;
    }

    if (hit.moveDirection.y < -0.3)
    {
      return;
    }

    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

    body.velocity = pushDir * pushPower;
  }

  private void OnControllerColliderHit(ControllerColliderHit hit)
  {
    if (hit.gameObject.CompareTag("Obstacle"))
    {
      Debug.Log("HALO, PRZESZKODA!");
    }
  }
}
