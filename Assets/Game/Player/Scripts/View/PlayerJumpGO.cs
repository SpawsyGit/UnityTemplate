using UnityEngine;

public class PlayerJumpGO : MonoBehaviour {
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Vector2 groundCheckOffset;
    [SerializeField] private float jumpForce = 750f;

    public LayerMask GroundMask => groundMask;
    public float JumpForce => jumpForce;
    public Vector2 GroundCheckOffset => groundCheckOffset;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + (Vector3)groundCheckOffset, 0.1f);
    }
}
