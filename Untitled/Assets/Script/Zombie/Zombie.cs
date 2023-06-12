using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "zombie", menuName = "zombie")]
public class Zombie : ScriptableObject
{
    public float hp, damage, speed;
}
