﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDecorator : EnemyDecorator
{
    // Start is called before the first frame update
    void Start()
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();
        enemy.Speed += 0.2F;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
