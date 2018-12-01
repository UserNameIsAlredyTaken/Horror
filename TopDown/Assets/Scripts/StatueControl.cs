using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueControl : MonoBehaviour
{

	public Collider2D visionCol;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
//		while (GetComponent<Collider2D>().IsTouching(visionCol))
//		{
//			Debug.Log("Видно!");
//		}
	}
	
}
