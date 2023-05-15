using UnityEngine;
using System.Threading.Tasks;

public class M16 : BaseGun
{
    public int burstDelayMS;

    public override async void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0)
        {
            if (ammoCount > 0)
            {
                base.Shoot();
                extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
                extra.cam.transform.eulerAngles -= extra.recoil;
                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }
            }

            await Task.Delay(burstDelayMS);

            if (ammoCount > 0)
            {
                base.Shoot();
                extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
                extra.cam.transform.eulerAngles -= extra.recoil;
                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }
            }

            await Task.Delay(burstDelayMS);

            if (ammoCount > 0)
            {
                base.Shoot();
                extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
                extra.cam.transform.eulerAngles -= extra.recoil;
                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }
            }

            if (ammoCount == 0)
            {
                extra.ammoText.color = Color.red;
            }
        }
    }
}