using UnityEngine;
using System.Collections;

public class Movement_ScriptEnemy1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float movementSpeed;
    Vector2 initialSpawnPoint;
    Vector2 targetPatrolPoint;
    bool isMoving = true;
    

    


    public float minX = 1.4f;
    public float maxX = 5.48f;
    public float minY = -3.48f;
    public float maxY = -0.40f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        transform.position = new Vector2(3.45f, -2.005f);
        initialSpawnPoint = transform.position;


        CreatePatrolPoint();
        while (targetPatrolPoint.x < 3.45f)
        {
            CreatePatrolPoint();

        }
        animator.SetBool("isRunning", true);


        

    }

  
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPatrolPoint, movementSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPatrolPoint) < 0.1f)
            {
                StartCoroutine(StopAndWait());
            }
        }
    }

   void CreatePatrolPoint()
    {

        float randomX = Random.Range(initialSpawnPoint.x - 2.05f, initialSpawnPoint.x + 2.05f);
        float randomY = Random.Range(initialSpawnPoint.y + 1.445f, initialSpawnPoint.y - 1.445f);

        Vector2 CurrentDestinationPoint = targetPatrolPoint;

        targetPatrolPoint = new Vector2(randomX, randomY);

        if (CurrentDestinationPoint.x > targetPatrolPoint.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    IEnumerator StopAndWait()
    {
        animator.SetBool("isRunning", false);
        isMoving = false;

       
        float waitTime = Random.Range(1f, 3f);
        yield return new WaitForSeconds(waitTime);

        
        CreatePatrolPoint();
        isMoving = true;
        animator.SetBool("isRunning", true);
    }

}
