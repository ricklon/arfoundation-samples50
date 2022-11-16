using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{

    [RequireComponent(typeof(ARRaycastManager))]



    public class TouchObject : PressInputBase
    {

        bool m_Pressed;

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }




        void Update()
        {

            if (Pointer.current == null || m_Pressed == false)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits))//, TrackableType.PlaneWithinPolygon))
            {
                
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        Debug.Log($"ifnotnull: hit.collider.enabled, {hit.transform.gameObject.name}: {hit.collider.enabled}");
                        //hit.collider.enabled = false;


                    } else {
                        Debug.Log($"else: hit.collider.enabled, {hit.transform.gameObject.name}: {hit.collider.enabled}");

                    }
                }

            }
        }

        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }

}