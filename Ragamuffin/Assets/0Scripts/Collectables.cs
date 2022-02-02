/*
Collectables.cs
cody
09/19/2021
1.0
Collectables DESCRIPTION GOES HERE
*/
using UnityEngine;

/// <summary>
/// Author: cody
/// Collectables CLASS DESCRIPTION GOES HERE
/// </summary>
public class Collectables : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    public AudioSource collect;
    [SerializeField]
    private Menu menu;
    private int savePictureData = 1;    // When OnTriggerEnter is called this will change playerprefs int to 1 which means
                                        // player has collected item and will be turned on / displayed when that 
                                        // specific menu opens.

    [SerializeField]
    private int pictureItemsArryNum;    //number neeeds to match in array in menu script. string[] picNames. 
                                        //If picture is collectable #1 then this number should be 0 in the inspector. 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            collect.Play();
            Invoke("Off", 0.5f);
            menu.SetSaveData(pictureItemsArryNum, savePictureData);
        }
    }
    public void Off()
    {
        gameObject.SetActive(false);
    }
}