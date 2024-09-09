

// Aynı işlemi birden fazla kez kullanıyorsak ve bu işlemin sonucu her seferinde aynı çıkıyorsa bunu yeniden hesaplamamak için
// bir proxy kullanabiliriz. Proxy, gerçek nesnenin yerine geçen bir nesnedir ve gerçek nesneye erişim sağlar. Proxy, gerçek
// nesneye erişim sağlarken ekstra işlemler yapabilir. Bu işlemler gerçek nesneye erişimden önce veya sonra yapılabilir. Proxy
// Tıpkı bir cache gibi çalışabilir.



CreditBase creditManager = new CreditManagerProxy();
Console.WriteLine(creditManager.Calculate());
Console.WriteLine(creditManager.Calculate()); // Tekrar hesaplama yapmaz, cache'den alır.

abstract class CreditBase
{
    public abstract int Calculate();
}

class CreditManager : CreditBase
{
    public override int Calculate()
    {
        int result = 1;
        for (int i = 1; i < 5; i++)
        {
            result *= i;
            Thread.Sleep(1000);
        }
        return result;
    }
}


class CreditManagerProxy : CreditBase
{
    private CreditManager _creditManager;
    private int _cachedValue;

    public override int Calculate()
    {
        if (_creditManager == null)
        {
            _creditManager = new CreditManager();
            _cachedValue = _creditManager.Calculate();
        }

        return _cachedValue;
    }
}
