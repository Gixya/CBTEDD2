using System;

public class Class1
{
	public Class1()
	{
	}
}

public class Venda
{
    private int qtde;
    private double valor;

    public Venda(int qtde, double valor)
    {
        this.qtde = qtde;
        this.valor = valor;
    }

    public double ValorMedio()
    {
        if (qtde == 0)
            return 0;

        return valor / qtde;
    }

    public double Valor
    {
        get { return valor; }
    }
}