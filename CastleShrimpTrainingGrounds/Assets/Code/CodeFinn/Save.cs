using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    private string savePath; 
    public Button saveButton;
    private PlayerBehavior player; 

    [System.Serializable]  

    private class PlayerData  // Een privéklasse om gegevens van de speler op te slaan
    {
        public float[] position = new float[3]; 
        public float health; 

        public PlayerData(Vector3 pos, float hp) 
        {
            position[0] = pos.x; 
            position[1] = pos.y;
            position[2] = pos.z;
            health = hp; 
        }
    }

    // Start is called before the first frame update
    void Start() 
    {
        savePath = Path.Combine(Application.persistentDataPath, "kevin2Data.json");
        player = GameObject.Find("Kevin2").GetComponent<PlayerBehavior>();

        if (saveButton != null) 
        {
            saveButton.onClick.AddListener(SaveGame);
        }
    }

    void SaveGame()  
    {
        if (player != null) 
        {
            PlayerData data = new PlayerData(player.transform.position, player.hp);
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(savePath, json);
            Debug.Log("Kevin2's data saved!"); 
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
