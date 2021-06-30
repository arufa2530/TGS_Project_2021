using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageScript : MonoBehaviour
{
    [SerializeField]public int baseBulletDamage;

    public int GetBulletDamage()
    {
        return baseBulletDamage;
    }
}
