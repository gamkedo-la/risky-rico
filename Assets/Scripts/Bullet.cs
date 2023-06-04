using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AmmoType _ammoType = AmmoType.NONE;
    [SerializeField] private GameObject _iceBlockPrefab;
    public AmmoType AmmoType => _ammoType;
    public bool CanBeDestoyedByEnemies = true;

    public void SetAmmoType(AmmoType ammoType)
    {
        _ammoType = ammoType;
    }

    public void ApplyAmmoEffect(GameObject target)
    {
        switch (_ammoType)
        {
            case AmmoType.FREEZE:
                FreezeEffect(target);
                break;
            case AmmoType.SHOCK:
                ShockEffect(target);
                break;
            default:
                break;
        }
    }

    public void FreezeEffect(GameObject target)
    {
        // spawn a frozen version of the enemy
        GameObject frozenTarget = Instantiate(gameObject, target.transform.position, Quaternion.identity);
        GameObject iceBlock = Instantiate(_iceBlockPrefab, target.transform.position, Quaternion.identity); 
        iceBlock.transform.SetParent(frozenTarget.transform);

        // set the frozen target's damage property to as high as possible
        frozenTarget.AddComponent<DamageController>();
        frozenTarget.GetComponent<DamageController>().SetDamage(10);

        // update sprite to match the target
        Sprite targetSprite = target.GetComponent<SpriteRenderer>().sprite;
        frozenTarget.GetComponent<SpriteRenderer>().sprite = targetSprite;
        frozenTarget.transform.localScale = new Vector3(1f, 1f, 1f);
        iceBlock.transform.localScale = new Vector3(1f, 1f, 1f);

        // make the frozen block indestructible by enemies
        Bullet bulletProperties = frozenTarget.GetComponent<Bullet>();
        bulletProperties.CanBeDestoyedByEnemies = false;
        bulletProperties.SetAmmoType(AmmoType.NONE);
        
        // destroy original target
        Destroy(target);
    }

    public void ShockEffect(GameObject target)
    {

    }
}
