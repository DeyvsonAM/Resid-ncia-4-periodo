using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.data;

namespace WebApplication1.Entities.sistemas;

public static class SistemasRotas
{
    public static void AddRotasSistemasOld(this WebApplication app)
    {
        RouteGroupBuilder rotaSistemas = app.MapGroup("sistemas");
        
        rotaSistemas.MapPost("",handler:async void (AddSistemaRequest request, AppDbContex context)=>
        {
            bool jaExite = await context.Sistemas.AnyAsync(sistema => sistema.Nome == request.Nome);
            
            //if (jaExite)
            //    return Results.Conflict("Ja existe una sistema encontrada.");
            
            var novoSistema = new Sistema(request.Nome, DateTime.Now);
            
            await context.Sistemas.AddAsync(novoSistema);
            
            await context.SaveChangesAsync();
            
           // return Results.Ok(novoSistema);
        });
    }
    
    public static void AddRotasSistemas(this WebApplication app)
    {
        RouteGroupBuilder rotaSistemas = app.MapGroup("sistemas");

        rotaSistemas.MapPost("", async (AddSistemaRequest request, AppDbContex context) =>
        {
            try
            {
                // Verifica se já existe um sistema com o mesmo nome
                bool jaExite = await context.Sistemas.AnyAsync(sistema => sistema.Nome == request.Nome);
            
                if (jaExite)
                    return Results.Conflict("Já existe um sistema com esse nome.");

                // Cria um novo sistema
                var novoSistema = new Sistema(request.Nome, DateTime.Now);
            
                // Adiciona o novo sistema ao contexto
                await context.Sistemas.AddAsync(novoSistema);
                await context.SaveChangesAsync();
            
                return Results.Ok(novoSistema);
            }
            catch (Exception ex)
            {
                // Retorna uma mensagem de erro genérica para evitar vazamento de informações
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        });
        
        //Retornar todos os sistemas
        rotaSistemas.MapGet("", async (AppDbContex contex) =>
        {
            var sistemas = await contex
                .Sistemas
                .Where(sistema => sistema.Active)
                
                .ToListAsync();
            return sistemas;
        });
        
        //Atualizar Sistemas
        rotaSistemas.MapPut("{id:guid}", async (Guid id, UpdateSistemaRequest request, AppDbContex contex) =>
        {
            var sistema = await contex.Sistemas.SingleOrDefaultAsync(sistema => sistema.Id == id);
            
            if (sistema == null)
                return Results.NotFound();
            
            sistema.AtualizarNome(request.Nome);
            
            await contex.SaveChangesAsync();

            return Results.Ok(sistema);
        });
    }

}