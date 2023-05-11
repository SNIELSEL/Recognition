using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0)
        {
            base.Shoot();
            ammoCount -= 1;
            extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
            extra.cam.transform.eulerAngles -= extra.recoil;
            base.extra.AmmoText.text = ammoCount.ToString() + "/" + startAmmo;
            
            if(ammoCount == 0)
            {
                extra.AmmoText.color = Color.red;
            }
        }
    }
}
