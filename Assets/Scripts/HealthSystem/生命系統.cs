using UnityEngine;

public class �ͩR�t��
{

    int �̤j��q;
    public int ��q { get; private set; }

    public �ͩR�t��(int �̤j��q)
    {
        this.�̤j��q = �̤j��q;
        ��q = �̤j��q;
    }

    public void ����ˮ`(int damageAmount)
    {
        ��q -= damageAmount;
        if (��q < 0)
        {
            ��q = 0;
        }
    }

    public void �v¡(int healAmount)
    {
        ��q += healAmount;
        if (��q > �̤j��q)
        {
            ��q = �̤j��q;
        }
    }

}
