using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortItem : MonoBehaviour
{
    [SerializeField] private Item _item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Fort") )
        {
            Fort fort = collision.GetComponent<Fort>();
            switch (_item.ItemType)
            {
                case ItemType.HealthPortion:
                    fort.Heal(_item.ItemValue);
                    break;

                case ItemType.ExpAddportion:
                    break;

                case ItemType.BulletAddportion:
                    break;

            }
           Destroy(gameObject);
        }
    }
}
