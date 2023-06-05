using UnityEngine;

public class M4A1 : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0)
        {
            base.Shoot();
            extra.recoil = new Vector3(recoilMain, -recoilMain / 5, 0);
            extra.cam.transform.localRotation = Quaternion.Euler(extra.recoil.y, extra.recoil.y, 0);

            base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

            if (extra.infiniteAmmo == false)
            {
                ammoCount -= 1;
            }

            if (ammoCount == 0)
            {
                extra.ammoText.color = Color.red;
                extra.weaponAmmoUi.color = Color.red;
            }

            extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
            extra.weaponAmmoUi.text = ammoCount.ToString();
        }
    }
}
