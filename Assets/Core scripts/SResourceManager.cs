using System.Collections.Generic;
public sealed class SResourceManager
{
    private List<ResourceClass> Inventory;
    private SResourceManager()
    {
        Inventory = new();
    }
    private static SResourceManager instance = null;
    public static SResourceManager Instance
    {
        get
        {
            instance ??= new(); // <- shortened version of if (x==null) {...} check, IDE suggested it.
            return instance;
        }
    }
    public ResourceClass GetResourceClassByType(ResourceTypes _type)
    {
        ResourceClass output = null;
        foreach (ResourceClass resourceClass in Inventory)
        {
            if (resourceClass.ResourceType.Equals(_type))
            {
                output = resourceClass;
                break;
            }
        }
        return output;
    }
    public int GetResourceCount(ResourceTypes _type)
    {
        ResourceClass targetResource = GetResourceClassByType(_type);
        int output = -1;
        if (targetResource != null)
        {
            output = targetResource.Count;
        }
        return output;
    }
    public void AddResource(ResourceTypes _type, int CountToAdd)
    {
        bool exsists = false;
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].ResourceType.Equals(_type))
            {
                exsists = true;
                Inventory[i].Count += CountToAdd;
                break;
            }
        }
        if (!exsists)
        {
            Inventory.Add(new(_type));
        }
    }
}
