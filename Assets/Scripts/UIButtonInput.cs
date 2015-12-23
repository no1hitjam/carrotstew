using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonInput : MonoBehaviour {
    
    public bool pressed = false;

    public bool getSinglePress()
    {
        if (this.pressed)
        {
            this.pressed = false;
            return true;
        }
        return false;
    }

    private EventTrigger trigger;

    void Start()
    {
        this.trigger = this.gameObject.AddComponent<EventTrigger>();
        // this.AddListener(EventTriggerType.PointerDown, (eventData) => { Down(); });
        // this.AddListener(EventTriggerType.PointerUp, (eventData) => { Up(); });
        this.AddListener(EventTriggerType.PointerEnter, (eventData) => { Down(); });
        this.AddListener(EventTriggerType.PointerExit, (eventData) => { Up(); });
    }

    private void AddListener(EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> call)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(call);
        this.trigger.triggers.Add(entry);
    }

    private void Down()
    {
        this.pressed = true;
    }

    private void Up()
    {
        this.pressed = false;
    }
}
