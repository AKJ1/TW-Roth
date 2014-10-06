using System;
using Assets.Controls;
using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour {

	// Use this for initialization
    public Vector2 movement { get; set; }
    void Start ()
    {
        MovementVariables.MoveSpeed = 4;
        MovementVariables.MaxSpeed = MovementVariables.MoveSpeed*1.10f;
        MovementVariables.TurnaroundTime = 0.1f;
        MovementVariables.Controller = ControlMethod.Joystick;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (MovementVariables.Controller == ControlMethod.Keyboard)
	    {
            keyboardMovement();
            keyboardLookAt();   
	    }
	    if (MovementVariables.Controller == ControlMethod.Joystick)
	    {
            joystickMovement();
	        joystickLookAt();
	    }
        Animate();
	}
    /*Animate Method needs to be moved, it's here for demo purposes.*/
    void Animate()
    {
        if (transform.rigidbody2D.velocity != Vector2.zero)
        {
            gameObject.GetComponent<Animator>().Play("Walking");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("Idle");   
        }
    }
   
    private void joystickMovement()
    {
        float x = Input.GetAxis("HorizontalJS");
        float y = Input.GetAxis("VerticalJS");
        transform.rigidbody2D.velocity = new Vector2(x * MovementVariables.MoveSpeed, y * MovementVariables.MoveSpeed);
    }

    private void joystickLookAt()
    {
        Vector3 diff = new Vector3(Input.GetAxis("VerticalRight") * 100, Input.GetAxis("HorizontalRight") * 100, 0f);
        if (Mathf.Abs(diff.x) > 0.2 || Mathf.Abs(diff.y) > 0.2)
        {
            var angle = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
    private void keyboardMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.rigidbody2D.velocity = new Vector2(x * MovementVariables.MoveSpeed, y * MovementVariables.MoveSpeed);
    }

	private void keyboardLookAt()
	{
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(transform.position.x, transform.position.y, -rot_z - 90);
	}
}
