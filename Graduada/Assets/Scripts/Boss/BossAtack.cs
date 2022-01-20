using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossAtack : MonoBehaviour
{    public GameObject proyectil;
    private float launchVelocity = 1200f;  //1000f
    private int shoot = 1;
    private float shootingDistance = 20f;
    private GameObject ball;
    Animator _animator;
    Vector3 posicionProyectil;
    GameObject target;
    public vidaEnemigo vida;
    public bool miraPJ;
    int attackMode = 1;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {   
        miraPJ = true;
        target = GameObject.FindGameObjectWithTag("Player");
        _animator = gameObject.GetComponent<Animator>();
        StartCoroutine(destruir(3f,null));
        
    }

    // Update is called once per frame
    void Update()
    {


        vida = FindObjectOfType<vidaEnemigo>();
        
        if(vida.health >= 8) attack2();

        
        if( vida.health < 8){
          attack2();
        }
       
      
    }
    //Ataque 1 simplemente dispara bolsas de basura
    void attack1(){
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (shoot == 1 && distance <= shootingDistance)
            {   
            Debug.Log("Ataco");
            _animator.SetBool("Disparo", true);
            shoot = 0;
            StartCoroutine(disparar1());
            // ¿Otra corutina?
            
            StartCoroutine(destruir(1.3f,ball));
            }
    }
    //Ataque 2 dispara circulo 
    void attack2(){
                float distance = Vector3.Distance(target.transform.position, transform.position);
      if (shoot == 1 && distance <= shootingDistance)
            {   
            Debug.Log("Ataco");
            _animator.SetBool("Disparo", true);
            shoot = 0;
            StartCoroutine(disparar2());
          
            
            StartCoroutine(destruir(1.3f,ball));
            }
            
            
            
    }

    IEnumerator disparar1(){
        yield return new WaitForSeconds(0.4f);
        Vector3 desp = new Vector3(2f,2f,2f);
        posicionProyectil = new Vector3(transform.position.x + transform.forward.x * desp.x, 4,
                                        transform.position.z + transform.forward.z * desp.z);

        ball = Instantiate(proyectil, posicionProyectil, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                (0, 0, launchVelocity));
        _animator.SetBool("Disparo", false);
    }

     IEnumerator disparar2(){
       
       
               
           do{
            time+= Time.deltaTime; 
        Vector3 desp = new Vector3(2f,2f,2f);
        posicionProyectil = new Vector3(transform.position.x + transform.forward.x * desp.x, 4,
                                        transform.position.z + transform.forward.z * desp.z);
        
        miraPJ = false;
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 500f);
        ball = Instantiate(proyectil, posicionProyectil, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                (0, 0, launchVelocity));
        
        
           }while (time < 0.3f);
            time = 0.0f;
       
        miraPJ = true;
                _animator.SetBool("Disparo", false);
                 yield return new WaitForSeconds(10f);
    }

    IEnumerator destruir(float time, GameObject ball)
    {
        yield return new WaitForSeconds(time);
        if (ball != null) Destroy(ball);
        if(!gameObject.GetComponent<vidaEnemigo>().muerto) shoot = 1;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);

    }
}
