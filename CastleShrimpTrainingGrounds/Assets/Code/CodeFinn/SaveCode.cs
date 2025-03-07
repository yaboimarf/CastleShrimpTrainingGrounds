
using UnityEngine;
using System.IO;
using System.Globalization;

public class SaveCode : MonoBehaviour
{
    private string filePath = "./";
    private string posFileName = "posTracker.txt";

     public void Save()
     {
       SavePosition();
     }
    private void SavePosition()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        string fullPath = Path.Combine(filePath, posFileName);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        // Force numbers to be saved with a dot as decimal separator
        using (StreamWriter outputFile = new StreamWriter(fullPath, false)) // Overwrite file
        {
            outputFile.WriteLine(
                $"{player.position.x.ToString(CultureInfo.InvariantCulture)}," +
                $"{player.position.y.ToString(CultureInfo.InvariantCulture)}," +
                $"{player.position.z.ToString(CultureInfo.InvariantCulture)}"
            );
        }

        Debug.Log("Saved Position to: " + fullPath);
    }
}
