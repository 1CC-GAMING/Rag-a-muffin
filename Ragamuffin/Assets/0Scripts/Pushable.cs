/*
Pushable.cs
cody
09/19/2021
1.0
Pushable DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// Pushable CLASS DESCRIPTION GOES HERE
/// </summary>
public class Pushable : MonoBehaviour
{

	/// <summary>
	/// Author: cody
	/// Start is called before the first frame update
	/// </summary>
    public Rag rag;
    //public bool onOff = false;
    public Rigidbody pushPullObject;
    private void Start()
    {
        pushPullObject = GetComponent<Rigidbody>();
    }
    private void Update()
    {
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "KinematicTag")
    //    {
    //        if (rag.child.transform.parent != null)
    //        {
    //            rag.child.transform.parent = null;
    //        }
    //        pushPullObject.isKinematic = false;
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == ("KinematicTag"))
    //    {
    //        pushPullObject.isKinematic = false;
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            pushPullObject.isKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(0, -test * Time.deltaTime, 0);
        //transform.position += new Vector3(test * Time.deltaTime, 0, 0);
        //transform.AddForce(Vector3.down * 5f * Time.deltaTime);
    }
}