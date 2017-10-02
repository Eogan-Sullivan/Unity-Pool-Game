using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodedSphere : MonoBehaviour
{

    //Coefficient of Restitution 
    float CoR = 0.5f, Mass = 1.0f, Mass1 = 1.0f;
    public Vector3 accelaration, velocity;
  //  public Rigidbody sphereBody;
    private bool collisionOccurred = false;
    private CodedSphere occurredWith;
    planeScript[] thePlanes;
  

  





    // Use this for initialization
    void Start()
    {

        thePlanes = FindObjectsOfType<planeScript>();
        






    }

    // Update is called once per frame
    void Update()
    {
        
        sphereAndPlane();

 

  
      


    }

    // if (transform.position.y < 0.5f)
    // {
    //   transform.position -= velocity * Time.deltaTime;
    //  velocity = -CoR*velocity; 

    //  }





    /// <summary>
    /// This returns the parallel component of the vector v parallel to n
    /// </summary>
    /// <param name="v"> Vector to Decompose</param>
    /// <param name="n"> Unit vector to decompose parallel to, this is usually a unit vector</param>
    /// <returns></returns>
    Vector3 parallelComponent(Vector3 v, Vector3 n)
    {

        Vector3 n1 = n.normalized;

        return Vector3.Dot(v, n1) * n1;

    }

    /// <summary>
    /// This returns the perpendicular component of the vector v parallel to n
    /// </summary>
    /// <param name="v"> Vector to Decompose</param>
    /// <param name="n"> Unit vector to decompose parallel to, this is usually a unit vector</param>
    /// <returns></returns>
    Vector3 perpendicularComponent(Vector3 v, Vector3 n)
    {


        return v - parallelComponent(v, n);


    }
    private void OnTriggerEnter(Collider collision)
    {


        if (!collisionOccurred)
        {
            CodedSphere otherSphere = collision.gameObject.GetComponent<CodedSphere>();

            if (otherSphere) collidesWith(otherSphere);
        }
        collisionOccurred = false;



    }

  

    private void collidesWith(CodedSphere otherSphere)
    {

            // sphereBody = otherSphere.GetComponent<Rigidbody>();
            // Mass = sphereBody.mass;
       
            Vector3 n = (transform.position - otherSphere.transform.position).normalized;

            Vector3 thisPerp = perpendicularComponent(velocity, n);
            Vector3 otherPerp = perpendicularComponent(otherSphere.velocity, n);

            Vector3 u1 = CoR *  parallelComponent(velocity, n);
            Vector3 u2 = CoR * parallelComponent(otherSphere.velocity, n);

            float M1 = Mass1, M2 = otherSphere.Mass;

            Vector3 v1 = ((M1 - M2) / (M1 + M2)) * u1 + (2 * M2 / (M1 + M2)) * u2;
            Vector3 v2 = ((M2 - M1) / (M1 + M2)) * u2 + (2 * M1 / (M1 + M2)) * u1;

            velocity =  thisPerp + v1;

            otherSphere.newVelocityAfterCollisionwith(this, otherPerp + v2);
        
 
    }

    private void newVelocityAfterCollisionwith(CodedSphere codedSphere, Vector3 newVelocity)
    {
        velocity = newVelocity;
        collisionOccurred = true;
        occurredWith = codedSphere;
      

    }



    void sphereAndPlane()
    {
        accelaration = 9.8f * Vector3.down;  //Physics.gravity
        velocity += accelaration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


        foreach (planeScript thePlane in thePlanes)
        {
            Vector3 fromPlaneToSphere = transform.position - thePlane.transform.position;
            Vector3 planeNormal = thePlane.transform.up;


            //Used to reverse the normals acting on the sphere to make it bounce
            if (parallelComponent(fromPlaneToSphere, planeNormal).magnitude < (this.transform.localScale.x / 2))

            {
                //pushes the sphere back above the surface and allows the perpendicular velocity to still act on the sphere
                transform.position -= parallelComponent(velocity * Time.deltaTime, planeNormal);

                velocity = perpendicularComponent(velocity, planeNormal) - CoR * parallelComponent(velocity, planeNormal);


            }
        }



    }



}




