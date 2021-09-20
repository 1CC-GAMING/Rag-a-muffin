/*
LevelLoader.cs
cody
09/19/2021
1.0
LevelLoader DESCRIPTION GOES HERE
*/
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Author: cody
/// LevelLoader CLASS DESCRIPTION GOES HERE
/// </summary>
public class LevelLoader : MonoBehaviour
{

    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void LoadLevel(string newScene)
    {
        Time.timeScale = 1; // This makes sure timescale is set to 1 when going to a new scene in case player is in the menu screen where timescale can be = to 0;
        SceneManager.LoadScene(newScene);
    }
    public void Exit()
    {
        Application.Quit(); // Closes out the game / executable.
    }
    public void SetVolume(float num)
    {//music volume
        PlayerPrefs.SetFloat("Volume", num);
        //Debug.Log(PlayerPrefs.GetFloat("Volume") + " test");
    }
    public void SetSoundEffectsVolume(float num)
    { // sound effects volume
        PlayerPrefs.SetFloat("Sound", num);
        //Debug.Log(PlayerPrefs.GetFloat("Sound") + " test");
    }
    public void ContinueGame()
    { // Continue from last level played. Default is first level.
        string temp = PlayerPrefs.GetString("lastlevel");
        if (temp != "")
        {
            SceneManager.LoadScene(temp);
        }
    }
}