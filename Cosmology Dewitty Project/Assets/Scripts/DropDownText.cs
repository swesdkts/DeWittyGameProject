using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDownText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject textInformation;
    
    void Start()
    {
        textInformation.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textInformation.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textInformation.SetActive(false);
    }
}
