
using UnityEngine;
using System.IO;

public class LoadCode : MonoBehaviour
{
    private string filePath = "./";
    private string posFileName = "posTracker.txt";

    public void Load()
    {
        LoadPosition();
    }

    private void LoadPosition()
    {
        if (File.Exists(Path.Combine(filePath, posFileName)))
        {
            Debug.Log("Position Tracker File Not Found!");
            return;
        }

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        using(StreamReader inputFile  = new StreamReader(Path.Combine(filePath, posFileName), true))
        {
            string Line = inputFile.ReadLine();
            while(!string.IsNullOrEmpty(Line)) 
            {
                player.position = StringToVector3(Line);
                Line = inputFile.ReadLine() ;
            }
                

        }
                
    }

    private Vector3 StringToVector3(string line)
    {
        Vector3 vector3 = new Vector3();
        string x =line.Substring(1, line.IndexOf(".") - 1);
        string y =line.Substring(x.Length + 3, line.Substring(x.Length + 3).IndexOf(","));
        y = y.Trim(' ');
        y = y.Trim(',');
        string z = line.Substring(x.Length + y.Length + 5, line.Substring(x.Length +y.Length + 5).IndexOf(")"));
        z = z.Trim(' ');
        z = z.Trim(',');
        vector3.x = float.Parse(x);
        vector3.y = float.Parse(y);
        vector3.z = float.Parse(z);
        return vector3;
    }
}