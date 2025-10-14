using UnityEngine;

public class Shelf : MonoBehaviour
{

    [SerializeField] private GameObject itemPrefab;

    public Item GetItem()
    {
        var item = Instantiate(itemPrefab);
        return item.GetComponent<Item>();
    }
}
