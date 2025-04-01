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
        public float[] position = new float[3];  // Een array van 3 floats voor de positie (x, y, z)
        public float health;  // Een float om de gezondheid van de speler te bewaren

        public PlayerData(Vector3 pos, float hp)  // Constructor om een nieuwe PlayerData te maken met positie en gezondheid
        {
            position[0] = pos.x;  // De x-coördinaat van de Vector3 wordt opgeslagen in position[0]
            position[1] = pos.y;  // De y-coördinaat van de Vector3 wordt opgeslagen in position[1]
            position[2] = pos.z;  // De z-coördinaat van de Vector3 wordt opgeslagen in position[2]
            health = hp;  // De gezondheidswaarde (hp) wordt opgeslagen in het health-veld
        }
    }

    // Start is called before the first frame update
    void Start()  // Deze methode wordt uitgevoerd als het script voor het eerst start in Unity
    {
        savePath = Path.Combine(Application.persistentDataPath, "kevinData.json");  // Maakt een bestandspad naar "kevinData.json" in een permanente map
        player = GameObject.Find("Kevin").GetComponent<PlayerBehavior>();  // Zoekt een GameObject genaamd "Kevin" en haalt zijn PlayerBehavior-component op

        if (saveButton != null)  // Controleert of de saveButton is ingesteld (niet null)
        {
            saveButton.onClick.AddListener(SaveGame);  // Voegt de SaveGame-methode toe als actie wanneer de knop wordt geklikt
        }
    }

    void SaveGame()  // Methode om de spelergegevens op te slaan
    {
        if (player != null)  // Controleert of de speler is gevonden en niet null is
        {
            PlayerData data = new PlayerData(player.transform.position, player.hp);  // Maakt een nieuwe PlayerData met de huidige positie en gezondheid van de speler
            string json = JsonUtility.ToJson(data);  // Converteert de PlayerData naar een JSON-string
            File.WriteAllText(savePath, json);  // Schrijft de JSON-string naar het bestand op het savePath
            Debug.Log("Kevin's data saved!");  // Geeft een bericht in de Unity-console dat de gegevens zijn opgeslagen
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
