using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    private static int level = 1;



    public int Level {
        get { return level; }
        set { level = value; }
    }
    protected override void Awake()
    {
        base.Awake();
    }
}
