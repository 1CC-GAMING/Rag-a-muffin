/*
Hint.cs
cody
09/19/2021
1.0
Hint DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// Hint CLASS DESCRIPTION GOES HERE
/// </summary>
public class Hint : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    // Hint will show up when entering a is trigger Collider with this script 
    // on it and go away upon leaving that Collider.
    public GameObject hint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            hint.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            hint.SetActive(false);
        }
    }
}