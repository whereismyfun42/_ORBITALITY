using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public float HP;
    public float Score;

    public PlayerData()
    {
        HP = HPController.instance.HP;
        Score = ScoreController.instance.Score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
