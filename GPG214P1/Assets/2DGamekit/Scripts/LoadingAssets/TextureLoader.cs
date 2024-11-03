using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureLoader : MonoBehaviour
{

    [SerializeField] private GameObject spriteTexture;
    //[SerializeField] private AudioClip audioClip;
    [SerializeField] private string textureFolder;
    [SerializeField] private string textureName;
    //[SerializeField] private string soundFolder;
    private string folderPath = Application.streamingAssetsPath;


    private void Awake()
    {
        if (spriteTexture == null)
        {
            spriteTexture = Resources.Load<GameObject>("TestTexture");
        }

        //if (spriteTexture != null)
        //{
        //    Instantiate(spriteTexture);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadTexture()
    {
        if (File.Exists(folderPath))
        {
            byte[] imageBytes = File.ReadAllBytes(folderPath + "/" + textureFolder + "/" + textureName);

            Texture2D texture = new Texture2D(2, 2);

            texture.LoadImage(imageBytes);

            spriteTexture.GetComponent<Renderer>().material.mainTexture = texture;
        }
        else
        {
            Debug.Log("Texture file not found at" + folderPath);
        }
    }
}
