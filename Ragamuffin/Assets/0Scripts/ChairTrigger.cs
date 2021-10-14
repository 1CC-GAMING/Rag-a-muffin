/*
ChairTrigger.cs
Kristyn
10/07/2021
1.0
ChairTrigger On ChairTrigger obj to set rocking chair animation trigger
*/
using UnityEngine;

/// <summary>
/// Author: Kristyn
/// ChairTrigger On ChairTrigger obj to set rocking chair animation trigger
/// </summary>
public class ChairTrigger : MonoBehaviour
{
	public Animator chairAnim;

	/// <summary>
	/// Author: Kristyn
	/// Checking Rag colliding with ChairTrigger obj
    /// Setting animation trigger RagNear
	/// </summary>
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			chairAnim.SetTrigger("RagNear");
		}
	}
}