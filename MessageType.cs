using LiteNetLib.Utils;

namespace RunAndTagCore;

public static class MessageType
{
    public const byte FullSnapshotType = 0;
    public const byte DeltaSnapshotType = 1;
    public const byte MovementInputType = 2;
    
    public static byte GetType(NetDataReader reader) => reader.GetByte();
}