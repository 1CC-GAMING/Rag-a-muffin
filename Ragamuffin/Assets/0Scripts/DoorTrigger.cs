/*
DoorTrigger.cs
Kristyn
11/03/2021
1.0
DoorTrigger Trigger to open door
*/
using UnityEngine;

/// <summary>
/// Author: Kristyn 
/// DoorTrigger Trigger for door
/// </summary>
public class DoorTrigger : MonoBehaviour
{
	public Animator doorAnim;
	bool isOpening;

	/// <summary>
	/// Author: Kristyn
	/// Start is called before the first frame update 
	/// </summary>
	void Start()
	{
		isOpening = false; //setting bool default
	}

	/// <summary>
	/// Author: Kristyn 
	/// Checking collision with Rag + setting bool for animation
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			doorAnim.SetBool("isOpening", true);
		}
	}
}