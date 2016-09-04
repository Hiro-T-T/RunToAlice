using UnityEngine;
using System.Collections;

public class PlayerInfo {

    public int HP;
    public float X;
    public float Y;
    public string Name;

    public PlayerInfo()
    {

    }
    public PlayerInfo(int hp, float x, float y, string name)
    {
        HP = hp;
        X = x;
        Y = y;
        Name = name;
    }

    public override string ToString()
    {
        return string.Format("HP : {0}, X : {1}, Y : {2}", HP, X, Y);
    }
}
