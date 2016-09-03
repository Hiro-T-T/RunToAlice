using UnityEngine;
using System.Collections;

public enum ObsType { Stone, Braver, Slime };

public class Obstacle
{

    public ObsType Type;
    public int HP;
    public bool isBreakable;
    public float X, Y, Z;

    public Obstacle()
    {

    }

    public Obstacle(ObsType type, int hp, bool isbreakable, float x, float y, float z)
    {
        Type = type;
        HP = hp;
        isBreakable = isbreakable;
        X = x;
        Y = y;
        Z = z;
    }

}
