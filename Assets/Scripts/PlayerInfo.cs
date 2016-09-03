using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public int HP;
    public float X;
    public float Y;

    public PlayerInfo()
    {

    }
    public PlayerInfo(int hp, float x, float y)
    {
        HP = hp;
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return string.Format("HP : {0}, X : {1}, Y : {2}", HP, X, Y);
    }
}
