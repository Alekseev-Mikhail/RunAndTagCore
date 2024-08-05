using Core;

namespace RunAndTagCore;

public class LocalWorld(Map map, Player me, Player friend)
{
    public Map Map => map;
    public Player Me => me;
    public Player Friend => friend; 
    
    public void Update(LocalWorld world)
    {
        map = world.Map;
        me = world.Me;
        friend = world.Friend;
    }
}