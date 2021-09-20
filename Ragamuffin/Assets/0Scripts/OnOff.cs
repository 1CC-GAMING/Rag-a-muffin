/*
OnOff.cs
cody
09/19/2021
1.0
OnOff DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// OnOff CLASS DESCRIPTION GOES HERE
/// </summary>
public class OnOff : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    bool objectOnOff = false;
    public GameObject uiOnOff;
    public void ObjectOnOff()
    {
        objectOnOff = !objectOnOff;
        uiOnOff.SetActive(objectOnOff);
    }
}