using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private int BaslangicSuresi;
    [SerializeField] private GameManager _GameManager;
    private void Start()
    {
        StartCoroutine(SayacBaslasin());
    }
    IEnumerator SayacBaslasin()
    {
        Sure.text = BaslangicSuresi.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();
            if (BaslangicSuresi==0)
            {
                gameObject.SetActive(false);
                break;
            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _GameManager.PotaBuyut(transform.position);
        gameObject.SetActive(false);
        Debug.Log("carptý");
    }
}
