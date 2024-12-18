using System.Collections.Generic;
using UnityEngine;

public class PlayerSphereMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RotationSpeed = 10f;
    public float XLimit = 15f;
    public float ZLimit = 5f;
    private bool _useMouseInput = true;

    public Vector3 MovementDirection;
    private Vector3 _lastMousePosition;

    void Start()
    {
        MovementDirection = Vector3.forward;
    }

    void Update()
    {
        DetectMouseMovement();

        if (_useMouseInput)
        {
            MoveWithMouse();
        }
        else
        {
            MoveWithKeyboard();
        }
    }

    void MoveWithKeyboard()
    {
        float moveX = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        if (moveX != 0 || moveZ != 0)
        {
            _useMouseInput = false;
            MovementDirection = new Vector3(moveX, 0, moveZ).normalized;
        }

        Vector3 newPosition = transform.position + new Vector3(moveX, 0, moveZ);
        newPosition.x = Mathf.Clamp(newPosition.x, -XLimit, 1);
        newPosition.z = Mathf.Clamp(newPosition.z, -ZLimit, ZLimit);

        transform.position = newPosition;
    }

    void MoveWithMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0)); // Plane at the player's y position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distanceToPlane;

        // Check if the ray intersects with the plane
        if (playerPlane.Raycast(ray, out distanceToPlane))
        {
            Vector3 targetPosition = ray.GetPoint(distanceToPlane); // Get the point on the plane
            targetPosition.y = transform.position.y;  // Keep the player's y-position fixed

            // Clamp the target position within the box limits
            targetPosition.x = Mathf.Clamp(targetPosition.x, -XLimit, 1);
            targetPosition.z = Mathf.Clamp(targetPosition.z, -ZLimit, ZLimit);

            // Calculate the movement direction towards the mouse
            MovementDirection = (targetPosition - transform.position).normalized;

            // Smoothly move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        }
    }

    void DetectMouseMovement()
    {
        if (Input.mousePosition != _lastMousePosition)
        {
            _useMouseInput = true;
        }

        _lastMousePosition = Input.mousePosition;
    }

}
