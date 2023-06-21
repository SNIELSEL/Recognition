using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AWP : BaseGun
{
    public GameObject scope;

    /*
    private void Start()
    {
        scope = GameObject.Find("Sniper zoom");
        print(scope);
        scope.SetActive(false);
    }
    */

    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0 && extra.reload == false)
        {
            if(GameObject.Find("Upgrades").GetComponent<UpgradeManage>().dubbleShot == true)
            {
                base.Shoot();
            }

            base.Shoot();

            GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;
            GameObject.Find("Player").GetComponent<Movement144>().x += recoilMain / 2;

            if (ammoCount == 0)


                if (extra.infiniteAmmo == false)

                    base.extra.ammoText.text = ammoCount.ToString() + "/" + (int)upgrade.ammoBoosted;

            if (extra.infiniteAmmo == false)
            {
                ammoCount -= 1;
            }

            if (ammoCount == 0)
            {
                extra.ammoText.color = Color.red;
                extra.reloadText.GetComponent<TextMeshProUGUI>().enabled = true;
            }

            base.extra.ammoText.text = ammoCount.ToString() + "/" + (int)upgrade.ammoBoosted;
        }
    }

    public override void ADS()
    {
        base.ADS();

        transform.GetComponent<WeaponSway>().enabled = false;
        scope.SetActive(true);
    }

    public override void Normal()
    {
        base.Normal();

        transform.GetComponent<WeaponSway>().enabled = true;
        scope.SetActive(false);
    }
}
