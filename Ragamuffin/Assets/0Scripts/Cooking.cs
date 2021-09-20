/*
Cooking.cs
cody
09/19/2021
1.0
Cooking DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// Cooking CLASS DESCRIPTION GOES HERE
/// </summary>
public class Cooking : MonoBehaviour
{
    public int recipe = 0;
    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GoodFood>())
        {
            addFood();
            Destroy(other.gameObject);
        }
    }
    private void addFood()
    {
        recipe++;
        if (recipe == 3)
        {
            solved();
        }
    }
    private void solved()
    {
        Debug.Log("Cooked!");
    }
}