using System.Collections.Generic;

public class SaveData
{
    public List<InventoryItem> Items { get; set; }
}

public class InventoryItem
{
    public int ID { get; set; }
    public string Name { get; set; }
}
