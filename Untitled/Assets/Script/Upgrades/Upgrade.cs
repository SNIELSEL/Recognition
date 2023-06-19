using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade")]

public class Upgrade : ScriptableObject
{
    public string upgradeName, bio;
    public Texture image;
    public float boostMulti;
    public Boosts boostType;

    public enum Boosts
    {
        hp,       
        damage,
        maxAmmo,
        reloadSpeed,
        extra
    }
}
