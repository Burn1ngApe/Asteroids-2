using UnityEngine;
public class Weapon 
{
    public void Shoot(IWeapon weapon)
    {
        weapon.Shoot();
    }
}



public interface IWeapon
{
    public void Shoot();
}
