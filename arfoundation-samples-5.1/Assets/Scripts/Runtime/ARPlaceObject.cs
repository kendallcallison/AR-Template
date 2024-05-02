using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using System.Collections;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.ARFoundation.Samples

{
    /// <summary>
    /// Subscribes to an <see cref="ARRaycastHitEventAsset"/>. When the event is raised, the
    /// <see cref="prefabToPlace"/> is instantiated at, or moved to, the hit position.
    /// </summary>
    public class ARPlaceObject : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The prefab to be placed or moved.")]
        GameObject m_PrefabToPlace;

        [SerializeField]
        [Tooltip("The pictures to be placed or moved.")]
        GameObject[] m_Pictures;

        [SerializeField]
        [Tooltip("The Scriptable Object Asset that contains the ARRaycastHit event.")]
        ARRaycastHitEventAsset m_RaycastHitEvent;

        GameObject m_SpawnedObject;

        static int imageIndex = 0;
        bool canPlace = true;

        /// <summary>
        /// The prefab to be placed or moved.
        /// </summary>
        public GameObject prefabToPlace
        {
            get => m_PrefabToPlace;
            set => m_PrefabToPlace = value;
        }

        /// <summary>
        /// The spawned prefab instance.
        /// </summary>
        public GameObject spawnedObject
        {
            get => m_SpawnedObject;
            set => m_SpawnedObject = value;
        }

        void OnEnable()
        {
            if (m_RaycastHitEvent == null || m_PrefabToPlace == null)
            {
                Debug.LogWarning($"{nameof(ARPlaceObject)} component on {name} has null inputs and will have no effect in this scene.", this);
                return;
            }

            if (m_RaycastHitEvent != null)
                m_RaycastHitEvent.eventRaised += PlaceObjectAt;
        }

        void OnDisable()
        {
            if (m_RaycastHitEvent != null)
                m_RaycastHitEvent.eventRaised -= PlaceObjectAt;
        }

        void PlaceObjectAt(object sender, ARRaycastHit hitPose)
        {
            if ( !EventSystem.current.IsPointerOverGameObject() )
            {
                if (canPlace)
                {
                    //imageIndex++;
                    Quaternion rotation = Quaternion.Euler(0, hitPose.pose.rotation.eulerAngles.y + 270, 0);
                    Vector3 position = hitPose.pose.position;
                    m_SpawnedObject = Instantiate(m_Pictures[imageIndex], position, rotation, hitPose.trackable.transform.parent);
                }
                StartCoroutine(WaitForNextPlacement());
            }  

        }

        IEnumerator WaitForNextPlacement()
        {
            canPlace = false;
            yield return new WaitForSeconds(1f);
            canPlace = true;
        }

        public void SelectImage( int imageID )
        {
            imageIndex = imageID;
        }
    }
}
