using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shotgun : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0 && extra.reload == false)
        {
            base.Shoot();
            base.Shoot();
            base.Shoot();
            base.Shoot();
            base.Shoot();

            if (GameObject.Find("Upgrades").GetComponent<UpgradeManage>().dubbleShot == true)
            {
                base.Shoot();
                base.Shoot();
                base.Shoot();
                base.Shoot();
                base.Shoot();
            }

            GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;

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
    public override void Reload()
    {
        GetComponentInChildren<Animation>()["ReloadShotgun"].speed = reloadTime / upgrade.reloadBoosted;
        base.Reload();
    }
}
