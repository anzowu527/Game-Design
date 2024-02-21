using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCtrl : MonoBehaviour
{
    public GameObject Tip;
    [Header("Stopping Time")]
    public float durationTimer = 5;
    [Header("Next Hit Gap")]
    public float MaxcoolDownTimer = 10;
    public Transform car1;
    public Transform car2;
    public Transform car3;
    public Transform player;

    public State3 current;
    public float MinDistance = 10;
    private float coolDowntimer;

    public ArcadeBikeController playerMovement;
    public CinemachineDollyCart dollyCart1; 
    private float originalDollySpeed1; 
    public CinemachineDollyCart dollyCart2; 
    private float originalDollySpeed2; 
    public CinemachineDollyCart dollyCart3; 
    private float originalDollySpeed3; 
    // Start is called before the first frame update
    void Start()
    {
        current = State3.Wait;
        Time.timeScale = 1;
        originalDollySpeed1 = dollyCart1.m_Speed;
        originalDollySpeed2 = dollyCart2.m_Speed;
        originalDollySpeed3 = dollyCart3.m_Speed;

    }

    // Update is called once per frame
    void Update()
    {
        if(current== State3.Wait)
        {
            if(Vector3.Distance(car1.position, player.position)< MinDistance 
            || Vector3.Distance(car2.position, player.position)< MinDistance
            || Vector3.Distance(car3.position, player.position)< MinDistance)
            {
                Open();
                current = State3.Stop;
                playerMovement.CanMove = false;
                dollyCart1.m_Speed = 0;
                dollyCart2.m_Speed = 0;
                dollyCart3.m_Speed = 0;
            }
        }
        else if(current== State3.Stop)
        {

        }
        else if(current== State3.CoolDown)
        {
            playerMovement.CanMove = true;
            dollyCart1.m_Speed = originalDollySpeed1;
            dollyCart2.m_Speed = originalDollySpeed2;
            dollyCart3.m_Speed = originalDollySpeed3;
            coolDowntimer += Time.deltaTime;
            if (coolDowntimer >= MaxcoolDownTimer)
            {
                current = State3.Wait;
                
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
        current = State3.CoolDown;
        coolDowntimer = 0;
    }
}
public enum State3
{
    Wait,
    CoolDown,
    Stop,
}