/*
VolumeSlider.cs
cody
09/19/2021
1.0
VolumeSlider DESCRIPTION GOES HERE
*/
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Author: cody
/// VolumeSlider CLASS DESCRIPTION GOES HERE
/// </summary>
public class VolumeSlider : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundEffectsSlider;
    /// <summary>
    /// Author: cody
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Volume"); // Slider for game music.
        soundEffectsSlider.value = PlayerPrefs.GetFloat("Sound"); // Slider for sound effects.
    }
}