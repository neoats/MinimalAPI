using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MinimalAPI.Controllers
{
    public static class MinimalAPI
    {
        public static void ConfigureApi(this WebApplication app)
        {
            //endpoint mapping
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users{id}", GetUser);
            app.MapPost("/Users", InsertUser);
            app.MapPut("/Users", UpdateUser);
            app.MapDelete("/Users", DeleteUser);

        }

        public static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {

                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> GetUser(int id, IUserData data)
        {
            try
            {
                var results = await data.GetUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);


            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        public static async Task<IResult> InsertUser(UserModel model, IUserData data)
        {
            try
            {
                await data.InsertUser(model);
                return Results.Ok();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateUser(UserModel model, IUserData data)
        {
            try
            {
                await data.UpdateUser(model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteUser(int id, IUserData data)
        {
            try
            {
                await data.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
