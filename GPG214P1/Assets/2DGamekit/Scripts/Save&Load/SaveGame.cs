using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Gamekit2D;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public class SaveGame : MonoBehaviour
{

    string path = Application.dataPath;
    string location;
    public float xPos, yPos, zPos;
    public Scene sceneName;
    public int sceneNumber;
    public int health;
    public bool isFlipped;
    [SerializeField] private string allInfo;
    [SerializeField] private GameObject player;
    [SerializeField] private Damageable _health;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private string fileName;
    [SerializeField] private string jsonFileName = "PlayerInfo.json";
    [SerializeField] private string folderPath = Application.streamingAssetsPath;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GetGameObjects();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player == null)
        {
            Debug.Log("Error: Player not found");

            GetGameObjects();
            return;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveData();
        }
    }

    void GetGameObjects()
    {
        player = GameObject.Find("Ellen");
        if (player == null) return;
        _health = player.GetComponent<Damageable>();
        _sprite = player.GetComponent<SpriteRenderer>();
        //loads the player again in case the scene changed
    }

    void SaveData()
    {
        xPos = player.transform.position.x;
        yPos = player.transform.position.y;
        zPos = player.transform.position.z;
        health = _health.CurrentHealth;
        isFlipped = _sprite.flipX;
        sceneName = SceneManager.GetActiveScene();
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        allInfo = sceneName.name;
        allInfo = sceneNumber.ToString();
        var jsonText = JsonUtility.ToJson(allInfo);
        allInfo = xPos.ToString() + "-" + yPos.ToString() + "-" + zPos.ToString();
        //allInfo = {xPos}
        //string jsonData = JsonUtility.ToJson();
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName + ".json"), jsonText);
    }

    void LoadData()
    {
        sceneName = SceneManager.GetActiveScene();
        //if (File.Exists(filePath) {
        //if (sceneName.buildIndex != allInfo)
        //if the sceneName isn't the same in the Json file, don't load the thing, else continue
        //loads the things from the JSON file
        //overrides the player along with it's values
        //gets the xPos, yPos, and zPos from the files, along with the other files
    }
}
