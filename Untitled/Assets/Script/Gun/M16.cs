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
            /*
            base.Shoot();
            ammoCount -= 1;

            GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;
            GameObject.Find("Player").GetComponent<Movement144>().x += recoilMain / 2;
            */

            if (ammoCount > 0)
            {
                base.Shoot();

                GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;
                GameObject.Find("Player").GetComponent<Movement144>().x += recoilMain / 2;

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

                GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;
                GameObject.Find("Player").GetComponent<Movement144>().x += recoilMain / 2;

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

                GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;
                GameObject.Find("Player").GetComponent<Movement144>().x += recoilMain / 2;

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
