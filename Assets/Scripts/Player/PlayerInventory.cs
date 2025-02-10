using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int stoneCount;
    public int woodCount;

   public  void IncrementStone()
    {
        stoneCount++;
    }
    public void IncrementWood()
    {
        woodCount++;
    }

}
