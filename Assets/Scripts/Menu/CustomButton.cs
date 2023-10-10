using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class CustomButton : Button {
    public CustomMenuManager menu;

    protected override void Awake() {
        menu = GetComponentInParent<CustomMenuManager>();
    }

    public override void OnPointerEnter(PointerEventData eventData) {
        base.OnPointerEnter(eventData);
        menu.setCirclesActives(true);
        menu.selected = transform.GetChild(0).gameObject;
    }

    public override void OnPointerExit(PointerEventData eventData) {
        base.OnPointerEnter(eventData);
        menu.setCirclesActives(false);
    }
}

