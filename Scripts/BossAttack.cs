using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    
    public int attackDamage = 1;
    public int enragedAttackDamage = 3;
    public BossBullet bulletPrefab;

    public float attackRange = 10f;
    public LayerMask attackMask;

    public void Attack() {
        Shoot();
    }

    public void EnragedAttack() {
        EnragedShoot();
    }
    
    private void Shoot() {
        BossBullet bullet = Instantiate(this.bulletPrefab, Boss_Idle.rb.transform.position, Boss_Idle.rb.transform.rotation);
        bullet.Project(Boss_Idle.rb.transform.up*-1);
        //FindObjectOfType<AudioManager>().Play("BossShoot");
    }

    private void EnragedShoot() {
        //BossBullet bullet = Instantiate(this.bulletPrefab, Boss_Idle.rb.transform.position, Boss_Idle.rb.transform.rotation);
        //bullet.Project(Boss_Idle.rb.transform.up*-1);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
