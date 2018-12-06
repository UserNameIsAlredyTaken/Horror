using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
	//more this value, less difference between forward speed and backward speed (1 is the minimal value, with which backward speed equals 0)
	[SerializeField]
	private float _speedCoeficent = 1;
	[SerializeField]
	private float _speed;

	private Rigidbody2D _thisRigidbody;
	private float _forwardInput;
	private float _sidwardInput;

	private void Awake()
	{
		_thisRigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		_forwardInput = Input.GetAxis("Vertical");
		_sidwardInput = Input.GetAxis("Horizontal");
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
		Vector2 movmentDirection = Vector2.up * _forwardInput + Vector2.right * _sidwardInput; //finding direction of movement
		Vector2 movmentAmount = (Vector2.Dot(movmentDirection, transform.up) + _speedCoeficent) * _speed * movmentDirection * Time.deltaTime; //using  different speeds whether we go forward or backward //		
		_thisRigidbody.MovePosition(_thisRigidbody.position + movmentAmount);//apply movement
	}
}
