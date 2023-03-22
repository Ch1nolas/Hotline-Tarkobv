using System;
using UnityEngine;

public class MovementAutomatic : MonoBehaviour
{
    enum TypeMovementBot { HorizontalBounce,VerticalBounce,HorizontalFromLeft, HorizontalFromRight,VerticalFromAbove, VerticalFromBelow }

    [SerializeField] TypeMovementBot typeMovementRobot;

    public float limiteXderecha = 1.3f;
    public float limiteXizquierda = -2.8f;
    public float vel = 0.01f;
    private bool moviendoDer = true;


    private Transform t;

    private void Awake()
    {
        t = GetComponent<Transform>();
    }
    private void Update()
    {
        try
        {
            switch (typeMovementRobot)
            {
                case TypeMovementBot.HorizontalBounce:
                    HorizontalBounce();
                    break;
                case TypeMovementBot.VerticalBounce:
                    VerticalBounce();
                    break;
                case TypeMovementBot.HorizontalFromLeft:
                    HorizontalFromLeft();
                    break;
                case TypeMovementBot.HorizontalFromRight:
                    HorizontalFromRight();
                    break;
                case TypeMovementBot.VerticalFromAbove:
                    VerticalFromAbove();
                    break;
                case TypeMovementBot.VerticalFromBelow:
                    VerticalFromBelow();
                    break;
            }
        }catch(Exception)
        {
            Debug.LogError("No se ha encontrado el componente Transform en el objeto actual");
        }
    }

    private void HorizontalBounce()
    {
        if (moviendoDer){
            HorizontalFromLeft();
        } else {
            HorizontalFromRight();
        }
    }

    private void VerticalBounce()
    {

    }

    private void HorizontalFromLeft()
    {
        if(t.position.x < limiteXderecha){
            t.position = new Vector3(t.position.x + vel, t.position.y);
        } else {
            moviendoDer = false;
        }
    }

    private void HorizontalFromRight()
    {
        if(t.position.x > limiteXizquierda){
            t.position = new Vector3(t.position.x - vel, t.position.y);
        } else {
            moviendoDer = true;
        }
    }

    private void VerticalFromAbove()
    {

    }

    private void VerticalFromBelow()
    {

    }
    
}
