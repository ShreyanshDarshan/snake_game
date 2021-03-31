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
    [SerializeField] Animator anim;
    [SerializeField] float defaultAnimSpeed = 1.8f;
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
        // check if input is being given
        if (slider.isTurning)
        {
            // modify the velocity according to the input given
            rigidbody.velocity = rotate(ReferenceVelocity, slider.RotAngle);
        }
        // if not, set the reference velocity (used to determine where to turn to when input is given)
        else
        {
            ReferenceVelocity = rigidbody.velocity;
        }
        // maintain the speed of the snake (if it slows down)
        rigidbody.velocity = rigidbody.velocity.normalized * movementSpeed;
        // if the snake stops/ gets stuck, move backwards
        if (rigidbody.velocity.magnitude < 0.2f)
        {
            rigidbody.velocity = -transform.up * movementSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate difference between snake's heading direction and velocity direction
        float headingOffsetAngle = Vector2.SignedAngle(transform.up, rigidbody.velocity);
        // Lerp the angle of rotation so that snake slowly turns towards the velocity direction
        float currentTurnAngle = Mathf.Lerp(0, headingOffsetAngle, turnSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, currentTurnAngle));

        // Setting the animation speed to match the movement speed
        anim.speed = movementSpeed / defaultAnimSpeed;
    }
}
