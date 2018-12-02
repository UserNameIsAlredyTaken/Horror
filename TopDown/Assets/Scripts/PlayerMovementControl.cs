using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
	//more this value, less difference between forward speed and backward speed (1 is the minimal value, with which backward speed equals 0)
	public float speedCoef = 1;
	public float speed;

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
	}

	private void Move()
	{
		Vector2 movmentDirection = Vector2.up * forwardInput + Vector2.right * sidwardInput; //finding direction of movement
		Vector2 movmentAmount = (Vector2.Dot(movmentDirection, transform.up) + speedCoef) * speed * movmentDirection * Time.deltaTime; //using  different speeds whether we go forward or backward //		
		thisRigidbody.MovePosition(thisRigidbody.position + movmentAmount);//apply movement
	}
}
