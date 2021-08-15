using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizarraManager : Interactable1
{
    bool on = false;
    GameObject player;
    int movimiento;
    public float fuerza;
    [SerializeField] GameObject student;
    [SerializeField] float fadeOutTime = 1f;
    [SerializeField] SpriteRenderer sprite;
    bool used = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {

        if (!used)
        {
            on = !on;
            StartCoroutine(Dibujo(sprite, on));
            student.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles++;
            used = !used;
        }
        
    }

    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para apagar/prender la luz.";
    }

    IEnumerator Dibujo ( SpriteRenderer _sprite, bool isOn)
    {
            Color tmpColor = _sprite.color;

            while (tmpColor.a < 1f)
            {
                tmpColor.a += Time.deltaTime / fadeOutTime;
                _sprite.color = tmpColor;

                if (tmpColor.a >= 1f)
                {
                    tmpColor.a = 1.0f;
                }
                yield return null;
            }
            _sprite.color = tmpColor;
        
    }
}
