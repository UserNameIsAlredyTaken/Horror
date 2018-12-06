using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private Collider2D _vision;
	[SerializeField]
	private float _speed;

	void FixedUpdate () {
		if (!Physics2D.IsTouching(GetComponent<Collider2D>(), _vision))
		{
			transform.Translate((_player.transform.position - transform.position) * _speed * Time.deltaTime);
		}
	}
}
