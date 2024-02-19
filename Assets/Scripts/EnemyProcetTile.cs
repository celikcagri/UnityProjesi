using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProcetTile : MonoBehaviour
{
    public int damageAmount = 21;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerController player = other.transform.GetComponent<PlayerController>();
            player.PlayerTakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
