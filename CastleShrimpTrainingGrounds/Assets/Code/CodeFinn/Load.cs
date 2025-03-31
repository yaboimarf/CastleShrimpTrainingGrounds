using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Load : MonoBehaviour
{
    private string savePath;
    public Button loadButton; // Assign this in Inspector
    private PlayerBehavior player;

    [System.Serializable]
    private class PlayerData
    {
        public float[] position = new float[3];
        public float health;
    }
    // Start is called before the first frame update
    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "kevinData.json");
        player = GameObject.Find("Kevin").GetComponent<PlayerBehavior>();

        if (loadButton != null)
        {
            loadButton.onClick.AddListener(LoadGame);
        }
    }
    void LoadGame()
    {
        if (File.Exists(savePath) && player != null)
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Vector3 position = new Vector3(
                data.position[0],
                data.position[1],
                data.position[2]
            );

            player.transform.position = position;
            player.hp = data.health;
            Debug.Log("Kevin's data loaded!");
        }
        else
        {
            Debug.Log("No save file found or player not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
