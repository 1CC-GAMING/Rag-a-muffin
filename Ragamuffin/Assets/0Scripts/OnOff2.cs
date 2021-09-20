/*
OnOff2.cs
cody
09/19/2021
1.0
OnOff2 DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// OnOff2 CLASS DESCRIPTION GOES HERE
/// </summary>
public class OnOff2 : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    public GameObject goOnOff;
    public GameObject otherOnOff;
    public void ObjectOnOff()
    {
        goOnOff.SetActive(false);
        otherOnOff.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObjectOnOff();
    }
}