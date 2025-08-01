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
                        UserId = req.UserId,
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
            route.MapGet("All-Messages", async (DataContext context) =>
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
        }
    }
}