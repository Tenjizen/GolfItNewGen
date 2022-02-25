using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShot : MonoBehaviour
{
    private void OnDestroy()
    {
        CircleCollider.Instance.shotMax++;
        AudioManager.Instance.PlaySound("snd_bonus");
        clamerde.Instance.bonus.enabled = true;
    }
}
