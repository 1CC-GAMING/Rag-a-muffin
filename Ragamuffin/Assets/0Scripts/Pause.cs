/*
Pause.cs
anonymous
12/10/2021
1.0
Pause DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: anonymous
/// Pause CLASS DESCRIPTION GOES HERE
/// </summary>
public class Pause : MonoBehaviour
{

	public GameObject panel;
	public bool paused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!paused)
			{
				panel.SetActive(true);
				paused = true;
				Time.timeScale = 0;
			}
            else
			{
				Time.timeScale = 1;
				panel.SetActive(false);
				paused = false;
			}
		}

	}
}