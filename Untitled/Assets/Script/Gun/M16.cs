using UnityEngine;
using System.Threading.Tasks;
using static BaseGun;

public class M16 : BaseGun
{
    public int burstDelayMS;

    public override async void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0 && extra.reload == false)
        {

            base.Shoot();
            ammoCount -= 1;

            if (ammoCount > 0)
            {
                base.Shoot();

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

                if (extra.infiniteAmmo == false)
                {
                    ammoCount -= 1;
                }

                base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

                if (ammoCount == 0)
                {
                    extra.ammoText.color = Color.red;
                }
            }
        }
    }
}
