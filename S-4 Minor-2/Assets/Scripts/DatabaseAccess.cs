using System;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;
using System.Linq;

public class DatabaseAccess : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://Baby6:OnePiece@cluster0.dgsb3lc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    void Start()
    {
        database = client.GetDatabase("InventoryManagementSystem");
        collection = database.GetCollection<BsonDocument>("InventoryManagementSystemCollection");

    }
/*
    public async void SaveDataToDataBase(string itemName, int quantity)
    {
        var document = new BsonDocument { { itemName, quantity } };
        await collection.InsertOneAsync(document);
    }

    internal void SaveDataToDataBase(string v, string text)
    {
        throw new NotImplementedException();
    }


*/
    public async Task<List<Available>> GetDataFromDataBase(string keyName)
{
    var filter = Builders<BsonDocument>.Filter.Exists(keyName);

    var cursor = await collection.FindAsync(filter);

    List<Available> availables = new List<Available>();
    await cursor.ForEachAsync(document =>
    {
        if (document.Contains(keyName)) // Check if the key exists in the document
        {
        
            var itemName = keyName;
            var quantity = document[keyName].ToInt32();

            Available available = new Available
            {
                itemName = itemName,
                quantity = quantity
            };
            availables.Add(available);
        }
    });

        string output = string.Join("\n", availables.Select(item => $"Item Name: {item.itemName} \n Quantity: {item.quantity}"));
        Debug.Log(output);

        return availables;
    }


    public async Task UpdateQuantityInDataBase(string itemName, int newQuantity)
    {
        var filter = Builders<BsonDocument>.Filter.Exists(itemName);

        var update = Builders<BsonDocument>.Update.Set(itemName, newQuantity);

        Debug.Log($"Filter: {filter.ToString()}, Update: {update.ToString()}");

        await collection.UpdateManyAsync(filter, update);
    }
}

//inline class
public class Available  
{
    public string itemName { get; set; }
    public int quantity { get; set; }
}
