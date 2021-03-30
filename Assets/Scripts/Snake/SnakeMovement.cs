using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1.0f;
    [SerializeField] float turnSpeed = 0.5f;
    Rigidbody2D rigidbody;
    [SerializeField] SliderControl slider;
    private Vector2 ReferenceVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * movementSpeed;
    }

    // rotate a Vector2 by an angle
    public static Vector2 rotate(Vector2 v, float angle)
    {
        return new Vector2  (
                                v.x * Mathf.Cos(angle * Mathf.Deg2Rad) - v.y * Mathf.Sin(angle * Mathf.Deg2Rad),
                                v.x * Mathf.Sin(angle * Mathf.Deg2Rad) + v.y * Mathf.Cos(angle * Mathf.Deg2Rad)
                            );
    }

    void FixedUpdate()
    {
        if (slider.isTurning)
        {
            rigidbody.velocity = rotate(ReferenceVelocity, slider.RotAngle);
        }
        else
        {
            ReferenceVelocity = rigidbody.velocity;
        }
        rigidbody.velocity = rigidbody.velocity.normalized * movementSpeed;
        if (rigidbody.velocity.magnitude < 0.2f)
        {
            rigidbody.velocity = -transform.up * movementSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float headingOffsetAngle = Vector2.SignedAngle(transform.up, rigidbody.velocity);
        float currentTurnAngle = Mathf.Lerp(0, headingOffsetAngle, turnSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, currentTurnAngle));
    }
}
