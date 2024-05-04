using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool GettingKnockedback { get; private set; }

    [SerializeField] private float GettingKnockedbackTime = 0.4f;

    private Rigidbody2D rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockedBack(Transform damageSouce, float knockbackThrust)
    {
        GettingKnockedback = true;
        Vector2 difference = (transform.position - damageSouce.position).normalized * knockbackThrust *rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(GettingKnockedbackTime);
        rb.velocity = Vector2.zero;
        GettingKnockedback = false;
    }

}
