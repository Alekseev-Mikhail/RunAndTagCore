using LiteNetLib.Utils;

namespace RunAndTagCore;

public struct PlayerIdentifier(string id, uint role) : INetSerializable
{
    public string Id => id;
    public uint Role => role;
    
    public void Serialize(NetDataWriter writer)
    {
        writer.Put(id);
        writer.Put(role);
    }

    public void Deserialize(NetDataReader reader)
    {
        id = reader.GetString();
        role = reader.GetUInt();
    }
}