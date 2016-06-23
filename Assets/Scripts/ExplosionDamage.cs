using UnityEngine;
using System.Collections;

public class ExplosionDamage : MonoBehaviour {
    //variables for the exposion damage
    public float lifetime = 1;
    public float radius = 0.1f;
    public float maxradius = 1f;
    public float damage = 100f;
    public float damagefalloff = 2f;

    //variables for number of enemies hit for bonus score
    private int enemyshit;

    // script reference
    Enemy enemyscriptref;

    // Use this for initialization
    void Start () {
        transform.localScale += new Vector3(radius, radius, radius);
        enemyshit = 0;
    }

    //this function grows the radius (make like explosion) and reduces damage the bigger the explosion
    public void radiusfunction()
    {
        if (radius <= maxradius)
        {
            radius += 0.1f;
            transform.localScale += new Vector3(radius, radius, radius);
            damage -= damagefalloff;
        }
    }

    //this is the lifetime of the exposion, then counds how many enemys were hit.
    public void lifetimetimer()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
            GameController.Instance.scorefunction(10, enemyshit);
        }
    }

	// Update is called once per frame
	void Update () {

        radiusfunction();
        lifetimetimer();
            
	}

    //when this collides with enemys it does damage, knockback and adds to the enemys hit for the multiple hit bonus
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            //reference the enemys script
            enemyscriptref = other.GetComponent<Enemy>();
            enemyscriptref.TakeDamage(damage);
            enemyscriptref.Knockback();
            enemyshit += 1;
        }
    }
}
