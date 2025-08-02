using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Real_Time_Chat.Data;
using Real_Time_Chat.Models;

namespace Real_Time_Chat.Http.Routes
{
    public static class UserRoutes
    {
        public static void UserRoute(this WebApplication app)
        {
            var route = app.MapGroup("cooked/user");

            //POST
            route.MapPost("", async (UserModel req, DataContext context) =>
            {
                try
                {
                    var user = new UserModel()
                    {
                        Id = Guid.NewGuid(),
                        UserName = req.UserName,
                    };

                    await context.AddAsync(user);
                    await context.SaveChangesAsync();

                    return Results.Ok("User created with sucess");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            //GET ALL USERS
            route.MapGet("", async (DataContext context) =>
            {
                try
                {
                    var All_Users = await context.User.ToListAsync();

                    if (All_Users == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(All_Users);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            //GET USER BY ID
            route.MapGet("users/{id:guid}", async (Guid id, DataContext context) =>
            {
                try
                {
                    var user = await context.User.FirstOrDefaultAsync(x => x.Id == id);

                    if (user == null) return Results.NotFound();

                    return Results.Ok(user);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            //DELETE USER
            route.MapDelete("remove/{id:guid}", async (Guid id, DataContext context) =>
            {
                try
                {
                    var user = await context.User.FirstOrDefaultAsync(x => x.Id == id);

                    if (user == null) return Results.NotFound();

                    context.Remove(user);
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