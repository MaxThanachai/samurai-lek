using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickupBehaviour : MonoBehaviour
{
    public float pickupRange = 2f;

    public int soul = 0;
    public int gold = 0;

    private string targetTag = "Loot";

    private void Update()
    {
        FindObjectsInArea();
    }

    private void FindObjectsInArea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                LootBehaviour loot = collider.gameObject.GetComponent<LootBehaviour>();
                if (loot && !loot.IsPickedUp())
                {
                    loot.PickUp(gameObject);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Color color = Color.yellow;
        color.a = 0.2f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, pickupRange);
    }

    public int GetSoul()
    {
        return soul;
    }

    public int SetSoul(int soul)
    {
        this.soul = soul;
        return this.soul;
    }

    public int ModifySoul(int soul)
    {
        this.soul = Mathf.Max(0, this.soul + soul);
        return this.soul;
    }

    public int GetGold()
    {
        return gold;
    }

    public int SetGold(int gold)
    {
        this.gold = gold;
        return this.gold;
    }

    public int ModifyGold(int gold)
    {
        this.gold = Mathf.Max(0, this.gold + gold);
        return this.gold;
    }
}
