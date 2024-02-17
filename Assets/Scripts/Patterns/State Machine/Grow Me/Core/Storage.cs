using System.Collections.Generic;

public class Storage
{
    public Dictionary<string, float> Crops {  get; private set; }

    public Storage()
    {
        Crops = new Dictionary<string, float>();
    }

    public void AddCrop(string key, float value)
    {
        if (!Crops.ContainsKey(key))
        {
            Crops.Add(key, value);
            return;
        }
        Crops[key] += value;
    }

    public void RemoveCrop(string key) 
    {
        if (!Crops.ContainsKey(key)) return;
        Crops.Remove(key);
    }

    public float GetCrop(string key)
    {
        return Crops[key];
    }
}
