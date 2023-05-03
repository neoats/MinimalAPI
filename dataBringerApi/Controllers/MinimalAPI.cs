using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;


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

        public static async Task<IActionResult> GetUsers(IUserData data)
        {
            try
            {
                var users = await data.GetUsers();
                /* return Ok(new SuccessDataResult<IEnumerable<UserModel>>(users));*/
                return new OkObjectResult(new SuccessDataResult<IEnumerable<UserModel>>(users));
            }
            catch (Exception ex)
            {
                /*  return BadRequest(new ErrorResult("badreq"));*/
                return new BadRequestObjectResult(new ErrorResult("badreq"));
            }
        }
        public static async Task<IActionResult> GetUser(int id, IUserData data)
        {
            try
            {
                var results = await data.GetUser(id);
                if (results == null) return new BadRequestObjectResult(new ErrorResult(Messages.UsersNotFound));
                return new OkObjectResult(new SuccessDataResult<UserModel>(results));


            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ErrorResult(Messages.InternalServerError));
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
