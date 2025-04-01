using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    private string savePath; 
    public Button loadButton;  
    private PlayerBehavior player;  // Een privé variabele om de PlayerBehavior-component van "Kevin" op te slaan

    [System.Serializable]  // Maakt de klasse serialiseerbaar zodat Unity deze kan omzetten van/naar JSON
    private class PlayerData  // Een privéklasse binnen Load om spelergegevens te structureren
    {
        public float[] position = new float[3];  // Een array van 3 floats voor de positie (x, y, z)
        public float health;  // Een float om de gezondheid van de speler te bewaren
    }

    // Start is called before the first frame update
    void Start()  
    {
        savePath = Path.Combine(Application.persistentDataPath, "kevin2Data.json");  // Maakt een bestandspad naar "kevinData.json" in een permanente map
        player = GameObject.Find("Kevin2").GetComponent<PlayerBehavior>();  // Zoekt een GameObject genaamd "Kevin" en haalt zijn PlayerBehavior-component op

        if (loadButton != null)  // Controleert of de loadButton is ingesteld (niet null)
        {
            loadButton.onClick.AddListener(LoadGame);  // Voegt de LoadGame-methode toe als actie wanneer de knop wordt geklikt
        }
    }

    void LoadGame() 
    {
        if (File.Exists(savePath) && player != null)  // Controleert of het bestand bestaat en de speler is gevonden
        {
            string json = File.ReadAllText(savePath);  // Leest de volledige tekst (JSON) uit het bestand op savePath
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);  // Converteert de JSON-string terug naar een PlayerData-object

            Vector3 position = new Vector3(  // Maakt een nieuwe Vector3 voor de positie van de speler
                data.position[0],  // x-coördinaat uit de geladen data
                data.position[1],  // y-coördinaat uit de geladen data
                data.position[2]   // z-coördinaat uit de geladen data
            );

            player.transform.position = position;  // Stelt de positie van "Kevin" in op de geladen positie
            player.hp = data.health;  // Stelt de gezondheid van "Kevin" in op de geladen gezondheid
            Debug.Log("Kevin2's data loaded!");  // Geeft een bericht in de Unity-console dat de gegevens zijn geladen
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
