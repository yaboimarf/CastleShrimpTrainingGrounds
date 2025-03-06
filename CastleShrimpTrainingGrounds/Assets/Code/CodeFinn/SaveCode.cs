
using UnityEngine;
using System.IO;

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
        Transform player = GameObject.FindGameObjectWithTag("player").transform;

        Debug.Log("Saved Position to: " + filePath + posFileName);

        File.Delete(Path.Combine(filePath, posFileName));

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, posFileName), true))
        {
            outputFile.WriteLine(player.position);
        }
    }
}
