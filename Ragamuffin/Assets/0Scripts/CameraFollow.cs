/*
CameraFollow.cs
cody
09/19/2021
1.0
CameraFollow DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// CameraFollow CLASS DESCRIPTION GOES HERE
/// </summary>
public class CameraFollow : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    public Transform target;
    public float smoothSpeed;
    public Vector3 offsetBase; // base offset of camera
    public Vector3 offsetFOV; // offset for larger view area
    public bool baseView = true;
    public bool FOV = false;


    private void FixedUpdate()
    {
        if (baseView && !FOV)
        {
            Base();
        }
        if (!baseView && FOV)
        {
            Fov();
        }
    }


    public void Base()
    {
        Vector3 desiredPosition = target.position + offsetBase;
        Vector3 smoothedPositon = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPositon; // Allows camera to follow the player.
    }

    public void Fov()
    {
        Vector3 desiredPosition = target.position + offsetFOV;
        Vector3 smoothedPositon = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPositon; // Allows camera to follow the player.
    }

    public void ToggleView()
    {
        if (baseView == true)
        {
            baseView = false;
        }
        else
        {
            baseView = true;
        }
        if (FOV == false)
        {
            FOV = true;
        }
        else
        {
            FOV = false;
        }
    }
}