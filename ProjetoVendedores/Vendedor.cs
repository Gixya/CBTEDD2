using System;

public class Class1
{
	public Class1()
	{
	}
}

public class Vendedor
{
    private int id;
    private string nome;
    private double percComissao;
    private Venda[] asVendas;

    public Vendedor(int id, string nome, double percComissao)
    {
        this.id = id;
        this.nome = nome;
        this.percComissao = percComissao;
        asVendas = new Venda[31];
    }

    public int Id
    {
        get { return id; }
    }

    public string Nome
    {
        get { return nome; }
    }

    public double PercComissao
    {
        get { return percComissao; }
    }

    public void RegistrarVenda(int dia, Venda venda)
    {
        if (dia >= 1 && dia <= 31)
            asVendas[dia - 1] = venda;
    }

    public double ValorVendas()
    {
        double total = 0;

        for (int i = 0; i < 31; i++)
        {
            if (asVendas[i] != null)
                total += asVendas[i].Valor;
        }

        return total;
    }

    public double ValorComissao()
    {
        return ValorVendas() * percComissao / 100;
    }

    public double ValorMedioVendas()
    {
        double total = 0;
        int dias = 0;

        for (int i = 0; i < 31; i++)
        {
            if (asVendas[i] != null)
            {
                total += asVendas[i].Valor;
                dias++;
            }
        }

        if (dias == 0)
            return 0;

        return total / dias;
    }

    public bool PossuiVendas()
    {
        for (int i = 0; i < 31; i++)
        {
            if (asVendas[i] != null)
                return true;
        }

        return false;
    }
}