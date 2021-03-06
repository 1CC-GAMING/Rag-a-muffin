/*
Menu.cs
cody
09/19/2021
1.0
Menu DESCRIPTION GOES HERE
*/
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Author: cody
/// Menu CLASS DESCRIPTION GOES HERE
/// </summary>
public class Menu : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject collectables;
    public Image[] images;
    private bool menuOnOff = false;
    private bool collectablesOnOff = false;
    private string[] picNames = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuOnOff = true;
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void SetSaveData(int numArry, int numBool)
    {
        PlayerPrefs.SetInt(picNames[numArry], numBool);
        int temp = PlayerPrefs.GetInt(picNames[numArry]);
        Debug.Log("picNames " + temp);
    }
    // public void UpdateCollection(int num){images[num].GetComponent<Image>().color = Color.white;} 

    public void MenuOff()
    {
        menuOnOff = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CollectionOnOff()
    {
        collectablesOnOff = !collectablesOnOff;
        collectables.SetActive(collectablesOnOff);
        if (collectablesOnOff)
        {
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("picNames " + PlayerPrefs.GetInt(picNames[i]));
                int temp = PlayerPrefs.GetInt(picNames[i]);
                if (temp == 1)
                {
                    images[i].enabled = true;
                }
                else
                    images[i].enabled = false;
            }
        }
    }
}