using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe, staminaGlobe;

    public void DropItems()
    {
        int rng = Random.Range(1, 5);

        if(rng == 4 || rng == 5) { return; }

        if (rng == 1)
        {
            Instantiate(healthGlobe, transform.position, Quaternion.identity);
        }

        if (rng == 2)
        {
            Instantiate(staminaGlobe, transform.position, Quaternion.identity);
        }

        if (rng == 3)
        {
            int randomAmmount = Random.Range(1, 4);

            for (int i = 0; i < randomAmmount; i++)
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
            }
        }
    }
}
