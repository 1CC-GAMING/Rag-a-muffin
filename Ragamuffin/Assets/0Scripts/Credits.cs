/*
Credits.cs
cody
09/19/2021
1.0
Credits DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// Credits CLASS DESCRIPTION GOES HERE
/// </summary>
public class Credits : MonoBehaviour
{

	/// <summary>
	/// Author: cody
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        gameObject.transform.Translate(Vector3.up * 20f * Time.deltaTime);
    }
}