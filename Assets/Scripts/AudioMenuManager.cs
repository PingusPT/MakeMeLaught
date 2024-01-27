using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;

public class AudioMenuManager : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SoundFxSlider;

    [Header("Mixers")]
    [SerializeField] AudioMixer MusicMixer;
    [SerializeField] AudioMixer SoundFxMixer;

    [Header("Others")]
    [SerializeField] string settingsFileName;

    void Start()
    {
        //Verifica se existe o ficheiro que guarda as settings, se não cria-o
        string filePath = Application.dataPath + settingsFileName;
        if (!File.Exists(filePath))
        {
            string[] content =
            {
                "Music Value: _-10",
                "SoundFX Value: _-10",
            };

            WriteTextToFile(filePath, content);

            PlayerPrefs.SetString("SettingsPath", filePath);
        }

        //Atualiza os valores dos mixers
        UpdateMixersBasedOnFile();

        //Atualiza os valores dos sliders
        UpdateSlidersBasedOnFile();
    }

    public void OnMusicSliderValueChanged()
    {
        MusicMixer.SetFloat("MusicVolume", MusicSlider.value);
    }


    public void OnSoundFxSliderValueChanged()
    {
        SoundFxMixer.SetFloat("SoundFxVolume", SoundFxSlider.value);
    }

    public void UpdateSlidersBasedOnFile()
    {
        string path = Application.dataPath + settingsFileName;
        string[] lines = File.ReadAllLines(path);

        for (int lineNumber = 0; lineNumber <= 1; lineNumber++)
        {
            int startOfWord = lines[lineNumber].IndexOf("_");
            float CurrentQuality;

            switch (lineNumber)
            {
                case 0:

                    CurrentQuality = float.Parse(lines[lineNumber].Substring(startOfWord + 1));
                    MusicSlider.value = CurrentQuality;
                    break;
                case 1:
                    CurrentQuality = float.Parse(lines[lineNumber].Substring(startOfWord + 1));
                    SoundFxSlider.value = CurrentQuality;
                    break;
            }
        }
    }

    public void UpdateMixersBasedOnFile()
    {
        string path = Application.dataPath + settingsFileName;
        string[] lines = File.ReadAllLines(path);

        for (int lineNumber = 0; lineNumber <= 1; lineNumber++)
        {
            int startOfWord = lines[lineNumber].IndexOf("_");
            float CurrentQuality;

            switch (lineNumber)
            {
                case 0:
                    CurrentQuality = float.Parse(lines[lineNumber].Substring(startOfWord + 1));
                    MusicMixer.SetFloat("MusicVolume", CurrentQuality);
                    break;
                case 1:
                    CurrentQuality = float.Parse(lines[lineNumber].Substring(startOfWord + 1));
                    SoundFxMixer.SetFloat("SoundFxVolume", CurrentQuality);
                    break;
            }
        }
    }

    public void SaveMixerValues()
    {
        string path = Application.dataPath + settingsFileName;
        string[] lines = File.ReadAllLines(path);

        for (int lineNumber = 0; lineNumber <= 1; lineNumber++)
        {
            switch (lineNumber)
            {
                case 0:
                    lines[lineNumber] = "Music Value: _" + MusicSlider.value;
                    break;
                case 1:
                    lines[lineNumber] = "SoundFX Value: _" + SoundFxSlider.value;
                    break;
            }
        }

        File.WriteAllLines(path, lines);
    }

    void WriteTextToFile(string fileName, string[] content)
    {
        //Escreve as linhas no ficheiro
        File.WriteAllLines(fileName, content);
    }
}
