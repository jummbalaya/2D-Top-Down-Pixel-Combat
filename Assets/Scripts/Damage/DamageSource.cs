using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    private int damageAmount = 0;

    private void Start()
    {
        //some weird bug at start of game here, doesnt break or stop the game but its anoying
        //when i have more time check this shit out so it will stop buggin my ocd
        MonoBehaviour currentActiveWeapon = ActiveWeapon.Instance.CurrentActiveWeapon;
        int weaponDamage = (currentActiveWeapon as IWeapon).GetWeaponInfo().weaponDamage;
        damageAmount = weaponDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        enemyHealth?.TakeDamage(damageAmount);
    }
}
