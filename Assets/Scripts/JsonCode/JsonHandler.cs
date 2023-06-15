using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Data;
using UnityEngine.Tilemaps;

public class JsonHandler : MonoBehaviour
{
    private string jsonFilePath = "data.json"; // stores the data of the player/device
    DataSet dataset = new DataSet();

    [System.Serializable]
    private class Data
    {
        public string Question;
        public int answers;
        public string[] opties;
    }
    [System.Serializable]
    private class DataSet
    {
        public List <Data> dataset; 
    }
    private void Start()
    {
        #region Generate_Json
        ///--------------------------Generate New Data File-------------------///
        //DataSet dataset = new DataSet();
        //dataset.dataset = new List<Data>();

        //// Add question 1
        //Data question1 = new Data();
        //question1.Question = "What is the capital of France?";
        //question1.answers = 4;
        //question1.opties = new string[] { "London", "Berlin", "Paris", "Madrid" };
        //dataset.dataset.Add(question1);

        //// Add question 2
        //Data question2 = new Data();
        //question2.Question = "Who painted the Mona Lisa?";
        //question2.answers = 4;
        //question2.opties = new string[] { "Pablo Picasso", "Claude Monet", "Leonardo da Vinci", "Vincent van Gogh" };
        //dataset.dataset.Add(question2);

        //WriteToJsonSet(dataset); // Writes data to JSON file
        //ReadFromJson(); // Reads data from JSON file

        //CreateJson(); // Creates a new JSON file
        #endregion
    }


    public string ReadquestionRequest()
    {
        DataSet dataset = ReadFromJson();
       // Debug.Log(dataset.dataset.Count + " Items in dataset ");
        return dataset.dataset[0].Question;
    }
    public string[] ReadanswersRequest(int vraagnummer)
    {
        DataSet dataset = ReadFromJson();
        Debug.Log(dataset.dataset.Count + " Items in dataset ");
        string[] Answernarray = new string[dataset.dataset[vraagnummer].opties.Length];
        for (int i = 0; i < dataset.dataset[vraagnummer].opties.Length; i++)
        {
            Answernarray[i] = dataset.dataset[vraagnummer].opties[i];
        }
        return Answernarray;
    }
    public bool IfNonExsistent()
    {
        bool a = false;
        if (File.Exists(jsonFilePath))
        {
            a = true;
        }
        return a;
    }
    private DataSet ReadFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            DataSet dataset = JsonUtility.FromJson<DataSet>(jsonData);
            return dataset;
        }
        else
        {
            Debug.LogWarning("JSON file not found: " + jsonFilePath);
        }
        Debug.LogWarning("datasetRead Error" + jsonFilePath);
        return dataset;
    }
    public void CreateJson(string _question,int _answers, string[] _options)
    {
        Data data = new Data();
        data.Question = _question;
        data.answers = _answers;
        data.opties = _options;

        dataset.dataset.Add(data);

        string jsonData = JsonUtility.ToJson(data);

        // Write JSON data to a new file
        string newJsonFilePath = "new_data.json";
        File.WriteAllText(newJsonFilePath, jsonData);

        Debug.Log("JSON file created: " + newJsonFilePath);
    }
    public void CreateJson() //creates a file with default questions
    {
        DataSet dataset = new DataSet();
        dataset.dataset = new List<Data>();

        // Add question 1
        Data question1 = new Data();
        question1.Question = "What is the largest planet in our solar system?";
        question1.answers = 4;
        question1.opties = new string[] { "Venus", "Mars", "Saturn", "Jupiter" };
        dataset.dataset.Add(question1);

        // Add question 2
        Data question2 = new Data();
        question2.Question = "Who wrote the novel 'Pride and Prejudice'?";
        question2.answers = 4;
        question2.opties = new string[] { "Charles Dickens", "Jane Austen", "Mark Twain", "F. Scott Fitzgerald" };
        dataset.dataset.Add(question2);

        string jsonData = JsonUtility.ToJson(dataset);

        // Write JSON data to a new file
        string newJsonFilePath = "new_data.json";
        File.WriteAllText(newJsonFilePath, jsonData);

        Debug.Log("Created newJSON");
    }
    public void AppendNewData(string newquestion, int SetNum, string[] opties )
    {
        if (File.Exists(jsonFilePath))
        {
            // Read existing JSON data from file
            string jsonData = File.ReadAllText(jsonFilePath);

            // Convert JSON data to object
            DataSet dataset = JsonUtility.FromJson<DataSet>(jsonData);

          Data newdata = new Data();
            newdata.Question = newquestion;
            newdata.opties = opties;
            newdata.answers = opties.Length;

            // Add the new data object to the dataset
            dataset.dataset.Add(newdata);

            // Write the updated dataset back to the JSON file
            File.WriteAllText(jsonFilePath, jsonData);
            Debug.Log("added data to the dataset");
        }
        else
        {
            Debug.LogWarning("JSON file not found: " + jsonFilePath);
        }
    }
}
        
