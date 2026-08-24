using System;

public class Class1
{
	public Class1()
	{
	}
}

public class Vendedores
{
    private Vendedor[] osVendedores;
    private int max;
    private int qtde;

    public Vendedores()
    {
        max = 10;
        qtde = 0;
        osVendedores = new Vendedor[max];
    }

    public bool AddVendedor(Vendedor v)
    {
        if (qtde >= max)
            return false;

        osVendedores[qtde] = v;
        qtde++;

        return true;
    }

    public bool DelVendedor(Vendedor v)
    {
        for (int i = 0; i < qtde; i++)
        {
            if (osVendedores[i].Id == v.Id)
            {
                if (osVendedores[i].PossuiVendas())
                    return false;

                for (int j = i; j < qtde - 1; j++)
                    osVendedores[j] = osVendedores[j + 1];

                osVendedores[qtde - 1] = null;
                qtde--;

                return true;
            }
        }

        return false;
    }

    public Vendedor SearchVendedor(Vendedor v)
    {
        for (int i = 0; i < qtde; i++)
        {
            if (osVendedores[i].Id == v.Id)
                return osVendedores[i];
        }

        return null;
    }

    public double ValorVendas()
    {
        double total = 0;

        for (int i = 0; i < qtde; i++)
            total += osVendedores[i].ValorVendas();

        return total;
    }

    public double ValorComissao()
    {
        double total = 0;

        for (int i = 0; i < qtde; i++)
            total += osVendedores[i].ValorComissao();

        return total;
    }

    public int Quantidade
    {
        get { return qtde; }
    }

    public Vendedor GetVendedor(int i)
    {
        if (i >= 0 && i < qtde)
            return osVendedores[i];

        return null;
    }
}