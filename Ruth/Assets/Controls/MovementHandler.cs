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
        MovementVariables.Controller = ControlMethod.Keyboard;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    keyboardMovement();
        Animate();
        LookAt();
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
    private void keyboardMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.rigidbody2D.velocity = new Vector2(x * MovementVariables.MoveSpeed, y * MovementVariables.MoveSpeed);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -100 , 100),
            Mathf.Clamp(transform.position.y, -100 , 100)
            );
    }

 
	private void LookAt()
	{
	    float mouseX = Input.mousePosition.x;
	    float mouseY = Input.mousePosition.y;

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(transform.position.x, transform.position.y, rot_z - 90);
        //Vector3 playerRotationAngle = objectPos - transform.position;

        //float angle = Mathf.Atan2(mouseX - transform.position.x, mouseY - transform.position.y)*Mathf.Deg2Rad;
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
	}
}
