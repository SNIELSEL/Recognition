using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManage : MonoBehaviour
{
    public Slot[] slots;
    public bool test;

    public float hpboost, damageBoost, reloadBoost, ammoBoost;
    public bool dubbleShot, enemyVision;

    private void Start()
    {
        hpboost = 1;
        damageBoost = 1;
        reloadBoost = 1;
        ammoBoost = 1;
    }

    private void Update()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Upgrade != null)
            {
                if (slots[i].Upgrade.boostType == Upgrade.Boosts.hp)
                {
                    hpboost = slots[i].Stacks * slots[i].Upgrade.boostMulti + 1;
                }

                if (slots[i].Upgrade.boostType == Upgrade.Boosts.damage)
                {
                    damageBoost = slots[i].Stacks * slots[i].Upgrade.boostMulti + 1;
                }

                if (slots[i].Upgrade.boostType == Upgrade.Boosts.reloadSpeed)
                {
                    reloadBoost = slots[i].Stacks * slots[i].Upgrade.boostMulti + 1;
                }

                if (slots[i].Upgrade.boostType == Upgrade.Boosts.maxAmmo)
                {
                    ammoBoost = slots[i].Stacks * slots[i].Upgrade.boostMulti + 1;
                }
            }
        }
    }

    public void Pickup(Upgrade upgrade)
    {
        for (int i = 0; i < slots.Length; i++)
        {

            if (slots[i].Upgrade == null)
            {
                slots[i].Upgrade = upgrade;
                slots[i].Stacks = 1;

                if (slots[i].Upgrade.boostType == Upgrade.Boosts.hp)
                {
                    GameObject.Find("Player").GetComponent<PlayerStats>().hp += slots[i].Upgrade.boostMulti * 100;
                }

                if (slots[i].Upgrade.boostType == Upgrade.Boosts.extra)
                {
                    if(slots[i].Upgrade.upgradeName == "Dubble shot")
                    {
                        dubbleShot = true;
                    }

                    if (slots[i].Upgrade.upgradeName == "Enemy Vision")
                    {
                        enemyVision = true;
                    }

                }

                return;
            }

            else if (slots[i].Upgrade == upgrade && slots[i].Upgrade.boostType != Upgrade.Boosts.extra)
            {
                slots[i].Stacks += 1;

                if (slots[i].Upgrade.boostType == Upgrade.Boosts.hp)
                {
                    GameObject.Find("Player").GetComponent<PlayerStats>().hp += slots[i].Upgrade.boostMulti * 100;
                }

                return;
            }
        }
    }
}
