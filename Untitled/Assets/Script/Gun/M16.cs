using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16 : BaseGun
{
    public float test;

    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0)
        {
<<<<<<< Updated upstream
            base.Shoot();
            ammoCount -= 1;
            extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
            extra.cam.transform.eulerAngles -= extra.recoil;
            base.extra.AmmoText.text = ammoCount.ToString() + "/" + startAmmo;
=======
            if (ammoCount > 0)
            {
                base.Shoot();
                extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
                extra.cam.transform.eulerAngles -= extra.recoil;

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }

                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
            }

            await Task.Delay(burstDelayMS);

            if (ammoCount > 0)
            {
                base.Shoot();
                extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
                extra.cam.transform.eulerAngles -= extra.recoil;

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }

                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
            }

            await Task.Delay(burstDelayMS);

            if (ammoCount > 0)
            {
                base.Shoot();
                extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
                extra.cam.transform.eulerAngles -= extra.recoil;

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }

                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
            }
>>>>>>> Stashed changes

            if (ammoCount == 0)
            {
                extra.AmmoText.color = Color.red;
            }
        }
    }
}
