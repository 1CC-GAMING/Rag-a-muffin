/*
MoveObject.cs
cody
09/25/2021
1.0
MoveObject DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// MoveObject CLASS DESCRIPTION GOES HERE
/// </summary>
public class MoveObject : MonoBehaviour
{
    public int gate;
    public float speed;
	/// <summary>
	/// Author: cody
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		
	}

	/// <summary>
	/// Author: cody
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        if (gate == 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (gate == 1)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (gate == 2)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }

    }
}