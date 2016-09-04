using UnityEngine;
using System.Collections;

public enum ObstacleState { Front, Back }

public class Obstacle : MonoBehaviour
{
    private int _cardnum;
    public int CardNum
    {
        get
        {
            return _cardnum;
        }
        set
        {
            _cardnum = value;
            if (_state == ObstacleState.Back)
                GetComponent<Renderer>().material = _material[0];
            else if (_state == ObstacleState.Front)
                GetComponent<Renderer>().material = _material[CardNum];
        }
    }
    
    private ObstacleState _state;
    public ObstacleState State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
            if (_state == ObstacleState.Back)
                GetComponent<Renderer>().material = _material[0];
            else if (_state == ObstacleState.Front)
                GetComponent<Renderer>().material = _material[CardNum];

        }
    }
    public Material[] _material;

    public Obstacle()
    {
        //GetComponent<Renderer>().material = _material[0];
    }

    // Use this for initialization
    void Start()
    {
        
    }

}
