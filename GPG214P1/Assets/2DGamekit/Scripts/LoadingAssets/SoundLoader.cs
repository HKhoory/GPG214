using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundLoader : MonoBehaviour
{

    [SerializeField] private string fileName;
    [SerializeField] private string folderName;
    [SerializeField] private AudioClip soundByte;
    [SerializeField] private string combinedFilePath;

    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {

        _audioSource.GetComponent<AudioSource>();

        combinedFilePath = Path.Combine(Application.streamingAssetsPath, folderName, fileName);

    }

    // Update is called once per frame
    void Update()
    {
        if (_audioSource == null)
        {
            Debug.Log("Error: Audio not found");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadSound();
        }
    }

    void LoadSound()
    {
        if (File.Exists(combinedFilePath))
        {
            byte[] audioData = File.ReadAllBytes(combinedFilePath);

            float[] dataArray = new float[audioData.Length / 2];

            for (int i = 0; i < dataArray.Length; i++)
            {
                short value = System.BitConverter.ToInt16(audioData, i * 2);

                dataArray[i] = value / 32768.0f;
            }

            soundByte = AudioClip.Create("Temp", dataArray.Length, 1, 44100, false);

            soundByte.SetData(dataArray, 0);
        }
        else
        {
            Debug.Log("Error: File path not found");
        }
    }

    void PlaySound()
    {
        if (soundByte == null)
        {
            Debug.Log("Error: No sound is loaded");
            return;
        }

        _audioSource.PlayOneShot(soundByte);
    }
}
