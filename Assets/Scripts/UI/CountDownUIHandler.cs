using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownUIHandler : MonoBehaviour
{
    public Text countDownText;
    public TopDownCarController carController; // Tambahkan referensi ke skrip TopDownCarController di sini

    private void Awake()
    {
        countDownText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownCO());
    }

    IEnumerator CountDownCO()
    {
        // Nonaktifkan kontrol mobil selama perhitungan mundur
        if (carController != null)
        {
            carController.enabled = false;
        }

        yield return new WaitForSeconds(0.3f);

        int counter = 3;

        while (true)
        {
            if (counter != 0)
                countDownText.text = counter.ToString();
            else
            {
                countDownText.text = "GO";

                // Aktifkan kembali kontrol mobil setelah perhitungan mundur selesai
                if (carController != null)
                {
                    carController.enabled = true;
                }

                GameManager.instance.OnRaceStart();

                break;
            }

            counter--;
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
