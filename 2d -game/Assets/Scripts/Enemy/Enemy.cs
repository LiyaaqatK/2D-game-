using UnityEngine;

public class Enemy : Entity
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Enemy Stats")]
    public int health;

    protected override void Start()
    {
        base.Start();
        //stateMachine.Initialize();
    }

    protected override void Update()
    {

        HandleCollectionDetection();
        //stateMachine.UpdateActiveState();  

    }

    // Called by bullets
    public virtual void OnHitByBullet()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Enemy died.");
        //Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Bullet"))
    {
        Debug.Log("Bullet hit enemy.");

        OnHitByBullet(); // Call the damage logic
        Destroy(collision.collider.gameObject); // Remove the bullet
    }
}
}
