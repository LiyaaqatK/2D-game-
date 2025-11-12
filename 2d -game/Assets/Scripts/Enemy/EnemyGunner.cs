using UnityEngine;

public class EnemyGunner : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
public override void OnHitByBullet()
    {
        base.OnHitByBullet();
        Debug.Log("EnemyGunner shot.");
        
    } 
}
