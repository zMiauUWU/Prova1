namespace Prova.Models;

public class Folha
{
    public int Id { get; set; }
    public double valor { get; set; }
    public int quantidade { get; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public int? funcionarioId { get; set; }
    public double salarioBruto { get; set; }
    public double impostoIrrf { get; set; }
    public double impostoInss { get; set; }
    public double impostoFgts { get; set; }
    public double salarioLiquido { get; set; }
    public Funcionario funcionario { get; set; } = null!;
    public Folha()
    {
        this.salarioBruto = this.quantidade * this.valor;
        this.impostoIrrf = calcularRenda();
        this.impostoInss = calcularInss();
        this.salarioLiquido = salarioBruto - impostoIrrf - impostoInss;
        this.impostoFgts = this.salarioBruto * 0.08;

    }
    public double calcularRenda()
    {
        if (this.salarioBruto < 1903.98)
        {
            return 0;
        }
        else if (this.salarioBruto < 2826.65)
        {
            return this.salarioBruto * 0.075 - 142.8;
        }
        else if (this.salarioBruto < 3751.05)
        {
            return this.salarioBruto * 0.15 - 354.8;
        }
        else if (this.salarioBruto < 4664.68)
        {
            return this.salarioBruto * 0.225 - 663.13;
        }
        return this.salarioBruto * 0.275 - 869.36;
    }
    public double calcularInss()
    {
        if (this.salarioBruto < 1693.72)
        {
            return this.salarioBruto * 0.08;
        }
        else if (this.salarioBruto < 2822.90)
        {
            return this.salarioBruto * 0.09;
        }
        else if (this.salarioBruto < 5645.80)
        {
            return this.salarioBruto * 0.11;
        }
        return 621.03;
    }
}