using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
	ParticleSystem lightningParticle;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    private RUISBlastGestureRecognizer blastGesture;

    void Awake ()
    {
		shootableMask = LayerMask.GetMask ("Shootable");
		lightningParticle = GetComponentInChildren<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        blastGesture = transform.parent.gameObject.GetComponentInChildren<RUISBlastGestureRecognizer>();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if( (Input.GetButton("Fire1")  || BlastGestureTriggered()) && timer >= timeBetweenBullets && Time.timeScale != 0)
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

        lightningParticle.Stop();
        gunAudio.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        GameObject nearestEnemey = findNearestTarget();
        shootRay.origin = transform.position;
        Vector3 distance = new Vector3(3, 3, 3);

        if (nearestEnemey != null)
        {
            distance = nearestEnemey.transform.position - transform.position;
            shootRay.direction = distance.normalized; // Normalized distance will give direction
        }
        else
        {
            shootRay.direction = transform.forward;
        }

        

        var shape = lightningParticle.shape;
        shape.length = distance.magnitude;

        Vector3 relativePos = nearestEnemey.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;

        if (Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            lightningParticle.Play();
            Destroy(shootHit.transform.gameObject);
            //EnemyHealth enemyHealth = shootHit.transform.gameObject.GetComponent<EnemyHealth>();
            //if(enemyHealth != null)
            //{
            //    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            //}
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

    bool BlastGestureTriggered()
    {
        if (blastGesture == null || !blastGesture.GestureIsTriggered())
        {
            return false;
        }
        else
        {
            transform.position = blastGesture.GetTriggeredHand().transform.position;
            return true;
        }
    }

    GameObject findNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject mytarget = null;
        float maxdistance = 100;

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
