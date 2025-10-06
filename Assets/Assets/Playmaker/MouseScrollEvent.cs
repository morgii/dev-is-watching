using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Input")]
    [Tooltip("Continuously detects mouse wheel scroll (up/down) and sends events every frame.")]
    public class MouseScrollEvent : FsmStateAction
    {
        [Tooltip("Event to send when the mouse wheel is scrolled up.")]
        public FsmEvent scrollUpEvent;

        [Tooltip("Event to send when the mouse wheel is scrolled down.")]
        public FsmEvent scrollDownEvent;

        [Tooltip("Scroll sensitivity threshold.")]
        public FsmFloat sensitivity;

        public override void Reset()
        {
            scrollUpEvent = null;
            scrollDownEvent = null;
            sensitivity = 0.01f;
        }

        public override void OnUpdate()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll > sensitivity.Value)
            {
                Fsm.Event(scrollUpEvent);
            }
            else if (scroll < -sensitivity.Value)
            {
                Fsm.Event(scrollDownEvent);
            }
        }
    }
}
