using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ActionsLifePack : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.L;
    public SOInt soInt;

    private void Start()
    {
        soInt = ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).soInt;
    }

    private void RecorverLife()
    {
        if (soInt.value > 0)
        {
            ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            Player.Instance.healthBase.ResetLife();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            RecorverLife();
        }
    }
}
