using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{

	public float forwardSpeed;
	public float backwardSpeed;

	private Rigidbody2D thisRigidbody;
	private float forwardInput;
	private float sidwardInput;

	private void Awake()
	{
		thisRigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		forwardInput = Input.GetAxis("Vertical");
		sidwardInput = Input.GetAxis("Horizontal");
		LookOnTheCursor();
		Move();
	}

	private void LookOnTheCursor()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z); //block rotating on Y and X axis
//		GetComponent<Rigidbody2D>().angularVelocity = 0;
	}

	private void Move()
	{
		Vector2 movmentDirection = Vector2.up * forwardInput + Vector2.right * sidwardInput; //finding direction of movement
		Vector2 movmentAmount = (forwardInput < 0) ? //using  different speeds whether we go forward or backward 
			backwardSpeed * movmentDirection * Time.deltaTime :
			forwardSpeed * movmentDirection * Time.deltaTime;
		thisRigidbody.MovePosition(thisRigidbody.position + movmentAmount);//apply movment
		
	}
}
