using UnityEngine;
using UnityEngine.Audio; // Namespace for the AudioMixer
using UnityEngine.UI; // Namespace for UI components

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer; // Assign your Audio Mixer in the Inspector
    public Slider volumeSlider; // Assign your volume Slider in the Inspector

    private float defaultVolume = 0.5f; // Default volume is 50%

    void Start()
    {
        // Set the slider's default value
        volumeSlider.value = defaultVolume;

        // Optionally, you can convert the slider value to a logarithmic scale
        SetVolume(volumeSlider.value);

        // Add a listener to call the SetVolume method whenever the slider value changes
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(volumeSlider.value); });
    }

    public void SetVolume(float sliderValue)
    {
        // Convert the slider value to a logarithmic scale for the audio mixer
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
}
