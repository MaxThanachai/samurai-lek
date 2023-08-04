using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LootTypes
{
    Soul,
    Gold,
}

public class LootBehaviour : MonoBehaviour
{
    [SerializeField] LootTypes lootType = LootTypes.Soul;
    [SerializeField] int lootValue = 1;

    GameObject pickedUpBy;
    float moveSpeed = -5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pickedUpBy || !pickedUpBy.transform)
        {
            return;
        }
        Vector3 direction = (pickedUpBy.transform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        moveSpeed = Mathf.Min(moveSpeed + 0.05f, 50f);
        if ((pickedUpBy.transform.position - transform.position).magnitude < 0.5f)
        {
            LootPickupBehaviour pickupBehaviour = pickedUpBy.GetComponent<LootPickupBehaviour>();
            switch (lootType)
            {
                case LootTypes.Soul:
                    pickupBehaviour.ModifySoul(lootValue);
                    break;
                case LootTypes.Gold:
                    pickupBehaviour.ModifyGold(lootValue);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }

    public void PickUp(GameObject pickedUpBy)
    {
        this.pickedUpBy = pickedUpBy;
    }

    public bool IsPickedUp()
    {
        return this.pickedUpBy != null;
    }
}
