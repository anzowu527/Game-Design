using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCtrl2 : MonoBehaviour
{
    public GameObject Tip;
    [Header("Stopping Time")]
    public float durationTimer = 5;
    [Header("Next Hit Gap")]
    public float MaxcoolDownTimer = 10;
    public Transform car1;
    public Transform player;

    public State2 current;
    public float MinDistance = 10;
    private float coolDowntimer;

    public ArcadeBikeController playerMovement;
    public CinemachineDollyCart dollyCart1; 
    private float originalDollySpeed1; 
    
    // Start is called before the first frame update
    void Start()
    {
        current = State2.Wait;
        Time.timeScale = 1;
        originalDollySpeed1 = dollyCart1.m_Speed;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(current== State2.Wait)
        {
            if(Vector3.Distance(car1.position, player.position)< MinDistance)
            {
                Open();
                current = State2.Stop;
                playerMovement.CanMove = false;
                dollyCart1.m_Speed = 0;
                
            }
        }
        else if(current== State2.Stop)
        {

        }
        else if(current== State2.CoolDown)
        {
            playerMovement.CanMove = true;
            dollyCart1.m_Speed = originalDollySpeed1;
            
            coolDowntimer += Time.deltaTime;
            if (coolDowntimer >= MaxcoolDownTimer)
            {
                current = State2.Wait;
                
            }
        }
    }
    public void Open()
    {
        Tip.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(Close());
    }
    IEnumerator Close()
    {
        yield return new WaitForSecondsRealtime(durationTimer);
        Tip.SetActive(false);
        Time.timeScale = 1;
        current = State2.CoolDown;
        coolDowntimer = 0;
    }
}
public enum State2
{
    Wait,
    CoolDown,
    Stop,
}