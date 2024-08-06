using Core;
using LiteNetLib.Utils;

namespace RunAndTagCore;

public static class NetworkSerializer
{
    public const byte FullSnapshotType = 0;

    public static NetDataWriter SerializeFullSnapshot(Map map, Player seeker, Player hider, byte role)
    {
        var writer = new NetDataWriter();

        writer.Put(FullSnapshotType);

        SerializeMap(writer, map);
        SerializePlayer(writer, seeker);
        SerializePlayer(writer, hider);
        writer.Put(role);

        return writer;
    }

    public static LocalWorld DeserializeFullSnapshot(NetDataReader reader)
    {
        var map = DeserializeMap(reader);
        var seeker = DeserializePlayer(reader);
        var hider = DeserializePlayer(reader);
        var role = reader.GetByte();
        return role == GameRole.Seeker ? new LocalWorld(map, seeker, hider) : new LocalWorld(map, hider, seeker);
    }

    private static void SerializePlayer(NetDataWriter writer, Player player)
    {
        writer.Put(player.X);
        writer.Put(player.Y);
        writer.Put(player.Direction);
        writer.Put(player.RayStep);
        writer.Put(player.MaxRayDistance);
        writer.Put(player.Fov);
        writer.Put(player.RotationVelocity);
        writer.Put(player.MovementVelocity);
    }

    private static Player DeserializePlayer(NetDataReader reader) => new(
        reader.GetFloat(),
        reader.GetFloat(),
        reader.GetFloat(),
        reader.GetFloat(),
        reader.GetFloat(),
        reader.GetFloat(),
        reader.GetFloat(),
        reader.GetFloat()
    );

    private static void SerializeMap(NetDataWriter writer, Map map)
    {
        writer.Put(map.TileSet);
        writer.Put(map.Width);
        writer.Put(map.WallTile);
    }

    private static Map DeserializeMap(NetDataReader reader) =>
        new(reader.GetString(), reader.GetInt(), reader.GetChar());
}