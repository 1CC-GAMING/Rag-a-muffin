/*
TextTrigger.cs
anonymous
12/03/2021
1.0
TextTrigger DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: anonymous
/// TextTrigger CLASS DESCRIPTION GOES HERE
/// </summary>
/// 

public class TextTrigger : MonoBehaviour
{
	public GameObject panel;
	/// <summary>
	/// Author: anonymous
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		
	}

	/// <summary>
	/// Author: anonymous
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player")
        {
			panel.SetActive(true);
		}
    }
    private void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player")
		{
			panel.SetActive(false);
		}
	}
}