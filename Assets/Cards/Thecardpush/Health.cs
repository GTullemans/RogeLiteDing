﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private int health; public int _Health { get { return (health); } set { health = value; } }
    private int maxhealth; public int _maxHealth { get { return (maxhealth); } set { maxhealth = value; } }
}
