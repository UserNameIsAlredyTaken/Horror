using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMovementControl : MonoBehaviour
{
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private float _speed;

	private bool _isVisible = false;

	void FixedUpdate () {
		if (!_isVisible)
		{
			//look on the player
			var dir = _player.transform.position - transform.position;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			//go to the player
			transform.Translate((_player.transform.position - transform.position) * _speed * Time.deltaTime); //go to the player
		}
		else
		{
			_isVisible = false;
		}
	}

	public void StayInThePlace()
	{
		_isVisible = true;
	}
}
