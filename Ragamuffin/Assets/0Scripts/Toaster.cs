/*
Toaster.cs
matt
09/19/2021
1.0
Toaster DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: matt
/// Toaster CLASS DESCRIPTION GOES HERE
/// </summary>
public class Toaster : MonoBehaviour
{
    public Animator toasterAnim;
    public Rigidbody rb;
    public float force;

    /// <summary>
    /// Author: matt
    /// Start is called before the first frame update
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        toasterAnim.SetBool("Yeeting", true);
        rb = other.GetComponent<Rigidbody>();
        Invoke("Yeet", 0.5f);
        Invoke("Base", 1.0f);
    }
    void OnTriggerExit()
    {
        toasterAnim.SetBool("Yeeting", false);
        toasterAnim.SetBool("Reset", true);
    }
    public void Base()
    {
        toasterAnim.SetBool("Reset", false);
    }
    public void Yeet()
    {
        rb.AddForce(1, force, 0, ForceMode.Impulse);

        Debug.Log("yeet");
    }
}
