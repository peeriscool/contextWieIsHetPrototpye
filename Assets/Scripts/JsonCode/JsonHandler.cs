using UnityEngine;
using System.IO;

public class JsonHandler : MonoBehaviour
{
    private string jsonFilePath = "data.json"; // stores the data of the player/device

    [System.Serializable]
    private class Data
    {
        public string Question;
        public int answers;
        public string[] opties;
    }

    private void Start()
    {
        //Debug.Log("creating Json File");
        //Data data = new Data();
        //data.Question = "ben je liever knap of slim";
        //data.answers = 4;
        //data.opties = new string[] { "voorbeeld1", "voorbeeld2", "voorbeeld3", "voorbeeld4" };

        //WriteToJson(data); // Writes/creates data to JSON file
        //ReadFromJson(); // Reads data from JSON file
    }

    private void WriteToJson(Data data)
    {
        string jsonData = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/data.json", jsonData);
        // Write JSON data to file
        File.WriteAllText(jsonFilePath, jsonData);

        Debug.Log("JSON data written to file: " + jsonFilePath);
    }

    private void ReadFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            // Read JSON data from file
            string jsonData = File.ReadAllText(jsonFilePath);

            // Convert JSON data to object
            Data data = JsonUtility.FromJson<Data>(jsonData);

            Debug.Log("question: " + data.Question);
            Debug.Log("options: " + data.answers);
            Debug.Log("answers: " + string.Join(", ", data.opties));
        }
        else
        {
            Debug.LogWarning("JSON file not found: " + jsonFilePath);
        }
    }
    public void CreateJson(string _question,int _answers, string[] _options)
    {
        Data data = new Data();
        data.Question = _question;
        data.answers = _answers;
        data.opties = _options;

        string jsonData = JsonUtility.ToJson(data);

        // Write JSON data to a new file
        string newJsonFilePath = "new_data.json";
        File.WriteAllText(newJsonFilePath, jsonData);

        Debug.Log("JSON file created: " + newJsonFilePath);
    }

}
