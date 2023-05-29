using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private SideType _sideType;

    public SideType SideType  => _sideType;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
