using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

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

    public async void SaveDataToDataBase(string itemName, int quantity)
    {
        var document = new BsonDocument { { itemName, quantity } };
        await collection.InsertOneAsync(document);
    }

    internal void SaveDataToDataBase(string v, string text)
    {
        throw new NotImplementedException();
    }



    public async Task<List<Available>> GetDataFromDataBase()
    {
        var allItemsTask = collection.FindAsync(new BsonDocument());
        var itemsAwaited = await allItemsTask;

        List<Available> availables = new List<Available>();
        foreach (var item in itemsAwaited.ToList())
        {
            availables.Add(Deserialize(item.ToString()));
        }

        return availables;
    }

    private Available Deserialize(string rawJson)
    {
        var availables = new Available();
        var stringWithoutID = rawJson.Substring(rawJson.IndexOf("),") + 4);
        var itemname = stringWithoutID.Substring(0, stringWithoutID.IndexOf(":") - 2);
        var available = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 2, stringWithoutID.IndexOf("}") - stringWithoutID.IndexOf(":") - 3);
        availables.itemName = itemname;
        availables.quantity = Convert.ToInt32(available);

        return availables;
    }

    
}


//inline class
public class Available
{
    public string itemName { get; set; }
    public int quantity { get; set; }
}