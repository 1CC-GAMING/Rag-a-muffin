/*
ShelfCollisionLeft.cs
kristyn
10/07/2021
1.0
ShelfCollisionLeft Checking collision for the shelves that fall to the LEFT
*/
using UnityEngine;

/// <summary>
/// Author: kristyn
/// ShelfCollisionLeft Checking collision for the shelves that fall to the LEFT
/// </summary>
public class ShelfCollisionLeft : MonoBehaviour
{
	private Animator shelfAnim; /// Animator for the shelf

	/// <summary>
	/// Author: kristyn
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		shelfAnim = GetComponent<Animator>(); /// Getting the animator component
	}

	/// <summary>
	/// Author: kristyn
	/// Checking collision with Rag + debug.log + setting animation bool
	/// </summary>
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Shelf Ready");
			shelfAnim.SetBool("isReadyLeft", true);
		}
	}
}