using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureLoader : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteTexture;
    [SerializeField] private string textureFolder;
    [SerializeField] private string textureName;
    [SerializeField] private string folderPath;

    [SerializeField] private Sprite testSprite;


    // Start is called before the first frame update
    void Start()
    {

        spriteTexture.GetComponent<SpriteRenderer>();

        folderPath = Path.Combine(Application.streamingAssetsPath, textureFolder, textureName);

        LoadSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadSprite()
    {
        if (File.Exists(folderPath))
        {
            byte[] imageBytes = File.ReadAllBytes(folderPath);

            Texture2D texture = new Texture2D(2, 2);

            texture.LoadImage(imageBytes);

            spriteTexture.GetComponent<Renderer>().material.mainTexture = texture;

            //testSprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), Vector2.zero);

            spriteTexture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);


        }
        else
        {
            Debug.Log("Texture file not found");
        }
    }
}
