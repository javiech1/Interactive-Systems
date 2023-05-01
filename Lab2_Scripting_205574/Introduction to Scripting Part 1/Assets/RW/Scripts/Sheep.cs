using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidBody;
    private SheepSpawner sheepSpawner;
    public float heartOffset;
    public GameObject heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay(){
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);

        //Make heart appear and shrink in the air
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();;
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;

        //play sound
        SoundManagers.Instance.PlaySheepHitClip();

        //Counter
        GameStateManager.Instance.SavedSheep();
    }
    private void Drop(){
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidBody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);

        SoundManagers.Instance.PlaySheepDroppedClip();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hay") && !hitByHay){
            Destroy(other.gameObject);
            HitByHay();
        }
        
        else if (other.CompareTag("DropSheep")){
            Drop();
        }
    }

    public void SetSpawner(SheepSpawner spawner){
        sheepSpawner = spawner;
    }
}
