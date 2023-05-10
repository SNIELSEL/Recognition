using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < timer && ammoCount > 0)
        {
            base.Shoot();
            ammoCount -= 1;
            recoil = new Vector3(recoilMain, 0, 0);
            cam.transform.eulerAngles -= recoil;
            base.AmmoText.text = ammoCount.ToString() + "/" + startAmmo;
            
            if(ammoCount == 0)
            {
                AmmoText.color = Color.red;
            }
        }
    }
}
