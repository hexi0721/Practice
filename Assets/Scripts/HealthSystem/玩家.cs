using UnityEngine;
using UnityEngine.UI;


public class ���a : MonoBehaviour
{
    �ͩR�t�� �ͩR�t��;
    [SerializeField] Button damageButton;
    [SerializeField] Button healButton;

    void Start()
    {
        �ͩR�t�� = new �ͩR�t��(100);

        �ͩR�t��.����ˮ`(10);
        Debug.Log(�ͩR�t��.��q);

        �ͩR�t��.�v¡(5);
        Debug.Log(�ͩR�t��.��q);


        damageButton.onClick.AddListener(() =>
        {
            �ͩR�t��.����ˮ`(10);
            Debug.Log(�ͩR�t��.��q);
        });

        healButton.onClick.AddListener(() =>
        {
            �ͩR�t��.�v¡(5);
            Debug.Log(�ͩR�t��.��q);
        });
    }
}
