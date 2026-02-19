public class ResourceClass
{
    public ResourceTypes ResourceType { get; private set; }
    public int Count { get; internal set; }
    public ResourceClass(ResourceTypes _type)
    {
        ResourceType = _type;
        Count = 1;
    }                                    
}
