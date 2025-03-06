
using UnityEngine;
using System.IO;
using System.Globalization;

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
     if (!File.Exists(Path.Combine(filePath, posFileName)))
      {
        Debug.Log("Position Tracker File Not Found!");
         return;
     }

     Transform player = GameObject.FindGameObjectWithTag("Player").transform;

     using(StreamReader inputFile = new StreamReader(Path.Combine(filePath, posFileName), true))
     {
         string Line = inputFile.ReadLine();
        while(!string.IsNullOrEmpty(Line)) 
        {
           player.position = StringToVector3(Line);
            Line = inputFile.ReadLine() ;
        }


     }

     }

    //private Vector3 StringToVector3(string line)
    //  {
    // Vector3 vector3 = new Vector3();
    //  string x =line.Substring(1, line.IndexOf(".") - 1);
    //string y =line.Substring(x.Length + 3, line.Substring(x.Length + 3).IndexOf(","));
    // y = y.Trim(' ');
    // y = y.Trim(',');
    // string z = line.Substring(x.Length + y.Length + 5, line.Substring(x.Length +y.Length + 5).IndexOf(")"));
    // z = z.Trim(' ');
    // z = z.Trim(',');
    // vector3.x = float.Parse(x);
    // vector3.y = float.Parse(y);
    // return vector3;
    // }
    private Vector3 StringToVector3(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            Debug.LogError("Invalid position string: Empty or null");
            return Vector3.zero;
        }

        line = line.Trim('(', ')'); // Remove parentheses if present
        string[] values = line.Split(',');

        if (values.Length != 3)
        {
            Debug.LogError($"Invalid position format: {line}");
            return Vector3.zero;
        }

        try
        {
            float x = float.Parse(values[0].Trim(), CultureInfo.InvariantCulture);
            float y = float.Parse(values[1].Trim(), CultureInfo.InvariantCulture);
            float z = float.Parse(values[2].Trim(), CultureInfo.InvariantCulture);

            return new Vector3(x, y, z);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error parsing position: {line} - {e.Message}");
            return Vector3.zero;
        }
    }
}