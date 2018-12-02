using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	public GameObject player;
	public Collider2D vision;
	public float speed;

	void FixedUpdate () {
		if (!Physics2D.IsTouching(GetComponent<Collider2D>(), vision))
		{
			transform.Translate((player.transform.position - transform.position) * speed * Time.deltaTime);
		}
	}
}
