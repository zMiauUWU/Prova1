using Prova.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDatabase>();
var app = builder.Build();

app.MapPost("api/funcionario/cadastrar", async ([FromBody] Funcionario funcionario, [FromServices] AppDatabase bancoDeDados) =>
{
    if (funcionario is not null)
    {
        bancoDeDados.Funcionarios.Add(funcionario);
        bancoDeDados.SaveChanges();
        return Results.Created("", funcionario);
    }

    return Results.NotFound();
});
app.MapGet("api/funcionario/listar", async ([FromServices] AppDatabase bancoDeDados) =>
{
    if (bancoDeDados.Funcionarios.Any())
    {
        return Results.Ok(bancoDeDados.Funcionarios.ToList());
    }
    return Results.NotFound();
});
app.MapPost("api/folha/cadastrar", async ([FromBody] Folha folha, [FromServices] AppDatabase bancoDeDados) =>
{
    if (folha == null)
    {
        return Results.NotFound();
    }


    var funcionario = bancoDeDados.Funcionarios.Find(folha.funcionarioId);
    if (funcionario == null)
    {
        return Results.NotFound();
    }
    folha = new Folha();
    folha.funcionario = funcionario;
    bancoDeDados.Folhas.Add(folha);
    await bancoDeDados.SaveChangesAsync();
    return Results.Created("", folha);
});
app.MapGet("api/folha/listar", async ([FromServices] AppDatabase bancoDeDados) =>
{
    if (bancoDeDados.Folhas.Any())
    {
        return Results.Ok(bancoDeDados.Folhas.ToList());
    }
    return Results.NotFound();
});
app.MapGet("api/folha/buscar/{cpfF}/{mes}/{ano}", async ([FromRoute] String cpfF, [FromRoute] int mes, [FromRoute] int ano, [FromServices] AppDatabase bancoDeDados) =>
{
    if (bancoDeDados.Folhas.Any())
    {

        var folha = bancoDeDados.Folhas.FirstOrDefaultAsync(f => f.funcionario.cpf == cpfF && f.mes == mes && f.ano == ano);

        return Results.Ok(folha);
    }
    return Results.NotFound();
});

app.Run();
