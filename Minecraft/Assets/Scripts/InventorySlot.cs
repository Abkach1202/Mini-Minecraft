using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
   //Drag and drop
   public void OnDrop(PointerEventData eventData)
   {
        if(transform.childCount == 0)
        {
            NewBehaviourScript newBehaviourScript = eventData.pointerDrag.GetComponent<NewBehaviourScript>();
            newBehaviourScript.parentAfterDrag = transform;
        }
   }
}
