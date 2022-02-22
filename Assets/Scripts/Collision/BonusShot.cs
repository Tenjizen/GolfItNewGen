using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShot : MonoBehaviour
{
    private void OnDestroy()
    {
        CircleCollider.Instance.shotMax++;
    }
}
