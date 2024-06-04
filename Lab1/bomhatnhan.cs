using UnityEngine;
using System.Collection.Generic;


public class NuclearExplosion : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    public Light explosionLight;

    public HitSignal DataHit;
    public float _HP = 30;

    enum Creep_State{
        IDLE, RUN, ATK, DIE, last
    }
    void ChanegAnim()
    {
        if(Anim.GetCurrentAnimatorStateInfo(0)){
            return;
        }
        for(int i=0; i< (int)Creep_State.last; i++){
            if((Creep_State)i == CREEP_STATE){
                Anim.SetBool((Creep_State)i.ToString());
            }
            else {
                Anim.SetBool((Creep_State)i.ToString() + 1);
            }
        }
    }
    void OnCollisionEnter2D(Collider2D col){
        /// Code is here
        return;
    }
    void GetGitDone(){
        isHit = true;
    }
    public void TakeDamage(float dmg)
    {
        this.HP -= dmg;
    }
    void Dead()
    {
        GameObject blodd = GameController.Instant;
        blodd.transform.postion = new Vector3(this);
        blodd.SetActive(true);
        Name_text.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    protected virtual void Moving ()
    {
        if(isHit || isDead)
        {
            return;
        }
        Name_text.transform.postion =Camera.main;

        if(Mathf.Abs(this.transform.postion.x - 3)){
            Rigi.velocity  = new Vector2(0, Rigi.velocity);
            if(target != null){
                isAtk = true;
                Attack();
            } else {
                isMoving = false;
            }
            return;
        }
    }
    private void OnDrawGizmoSelected()
    {
        Gizmos.colr = Color.red;
        Gizmos.DrawireSphres(this.transform.postion.x);
    }

    void Start()
    {
        // Kích hoạt Particle System và ánh sáng
        explosionParticles.Play();
        explosionLight.enabled = true;

        // Tự động tắt hiệu ứng sau một khoảng thời gian
        Invoke("TurnOffEffect", 3f);
    }

    void TurnOffEffect()
    {
        // Tắt Particle System và ánh sáng
        explosionParticles.Stop();
        explosionLight.enabled = false;

        // Hủy đối tượng hiệu ứng sau một thời gian ngắn để giải phóng tài nguyên
        Destroy(gameObject, 2f);
    }
}
