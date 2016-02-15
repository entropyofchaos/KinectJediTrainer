using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 1000f;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
	ParticleSystem LightningParticle;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    private RUISTposeGestureRecognizer tposeGesture;


    void Awake ()
    {
		shootableMask = LayerMask.GetMask ("Shootable");
		LightningParticle = GetComponentInChildren<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        tposeGesture = transform.parent.gameObject.GetComponentInChildren<RUISTposeGestureRecognizer>();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if( (Input.GetButton("Fire1")  || TposeGestureTriggered()) && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;

    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

		LightningParticle.Stop ();
		LightningParticle.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        GameObject nearestEnemey = findNearestTarget();
        shootRay.origin = transform.position;

        if (nearestEnemey != null)
        {
            Vector3 direction = nearestEnemey.transform.position - transform.position;
            shootRay.direction = direction.normalized;
        }
        else
        {
            shootRay.direction = transform.forward;
        }

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

    bool TposeGestureTriggered()
    {
        if (tposeGesture == null) return false;

        return tposeGesture.GestureIsTriggered();
    }

    GameObject findNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject mytarget = null;
        float maxdistance = 1000;

        foreach (GameObject enemy in targets)
        {
            //work out which item is the closest and shoot at it, or find out which enemy has the most armour left or the most power and shoot it.

            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < maxdistance)
            {
                mytarget = enemy;
                maxdistance = distance;
            }
        }

        return mytarget;
    }
}
