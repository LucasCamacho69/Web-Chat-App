using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Real_Time_Chat.Data;
using Real_Time_Chat.Models;

namespace Real_Time_Chat.Http.Routes
{
    public static class MessagesRoutes
    {
        public static void MessagesRoute(this WebApplication app)
        {
            var route = app.MapGroup("Chat");

            // HTTP POST
            route.MapPost("/new", async (MessageModel req, DataContext context) =>
            {
                try
                {
                    var message = new MessageModel()
                    {
                        Id = Guid.NewGuid(),
                        UserName = req.UserName,
                        Content = req.Content,
                        SendedAt = DateTime.UtcNow
                    };

                    await context.AddAsync(message);
                    await context.SaveChangesAsync();

                    return Results.Ok("Message sent");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            //HTTP GET
            route.MapGet("messages", async (DataContext context) =>
            {
                try
                {
                    var All_Messages = await context.Message.ToListAsync();

                    if (All_Messages == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(All_Messages);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            //HTTP GET BY ID
            route.MapGet("messages/{id:guid}", async (Guid id, DataContext context) =>
            {
                try
                {
                    var message = await context.Message.FirstOrDefaultAsync(x => x.Id == id);

                    if (message == null) return Results.NotFound();

                    return Results.Ok(message);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            
            //HTTP PUT
            route.MapPut("edit/{id:guid}", async (Guid id, MessageModel req, DataContext context) =>
            {
                try
                {
                    var message = await context.Message.FirstOrDefaultAsync(x => x.Id == id);

                    if (message == null) return Results.NotFound();

                    message.ChangeMessage(req.Content);
                    await context.SaveChangesAsync();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            //HTTP REMOVE
            route.MapDelete("remove/{id:guid}", async (Guid id, DataContext context) =>
            {
                try
                {
                    var message = await context.Message.FirstOrDefaultAsync(x => x.Id == id);

                    if (message == null) return Results.NotFound();

                    context.Remove(message);
                    await context.SaveChangesAsync();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }
    }
}