using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;


public class CollectCurse : MonoBehaviour
{
    [SerializeField] GameObjectCollection _curseCollection;
    [SerializeField] PlayerCurseSlots _curseSlots;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_curseCollection.Contains(collision.gameObject))
        {
            // Get curse and activate its effect
            Curse curseComponent = collision.gameObject.GetComponent<Curse>();
            if (curseComponent != null)
            {
                _curseSlots.AddCurse(curseComponent.Parameters);
            }

            Destroy(collision.gameObject);
        }
    }
}
