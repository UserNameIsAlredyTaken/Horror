using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueSearching : MonoBehaviour
{

	[SerializeField]
	private GameObject _player;

	private FieldOfView _fov;
	
	
	private void Start ()
	{
		_fov = _player.GetComponent<FieldOfView>();
	}
	
	private void FixedUpdate()
	{
		_fov.FindVisibleEnemies(); //finding all visible enemies
		foreach (var enemy in _fov._visibleEnemies)
		{
			enemy.GetComponent<StatueMovementControl>().StayInThePlace(); //for each enemy say not to follow player
		}
	}
}
