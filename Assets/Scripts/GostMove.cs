using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostMove : MonoBehaviour {

	public Transform[] waypoints;
	int cur = 0;
	public float speed = 0.3f;
	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		if(transform.position != waypoints[cur].position){
			Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}

		else {
			cur = (cur+1) % waypoints.Length;

			Vector2 dir = waypoints[cur].position - transform.position;
			GetComponent<Animator>().SetFloat("DirX", dir.x);
			GetComponent<Animator>().SetFloat("DirY", dir.y);
		}
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "packman"){
			Destroy(other.gameObject);
		}
	}
}
