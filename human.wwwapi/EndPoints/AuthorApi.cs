using human.models;
using human.repository;
using Microsoft.EntityFrameworkCore.Design;

namespace human.wwwapi.EndPoints
{
    public static class AuthorApi
    {

        public static void ConfigureAuthorApi(this WebApplication app)
        {
            app.MapGet("/authors", GetAuthors);
            app.MapGet("/authors/{id}", GetAuthor);
            app.MapPost("/authors", InsertAuthor);
            app.MapPut("/authors", UpdateAuthor);
            app.MapDelete("/authors", DeleteAuthor);
        }
        private static async Task<IResult> GetAuthors(IDatabaseRepository<Author> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return Results.Ok(service.GetAll());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetAuthor(int id, IDatabaseRepository<Author> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var person = service.GetById(id);
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertAuthor(Author author, IDatabaseRepository<Author> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (author == null) return Results.NotFound();
                    service.Insert(author);
                    return Results.Ok();
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateAuthor(Author author, IDatabaseRepository<Author> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if(author==null) return Results.NotFound();
                    if (!service.Table.Any(x => x.Id == author.Id)) return Results.NotFound();
                    service.Update(author);
                    service.Save();
                    return Results.Ok();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteAuthor(int id, IDatabaseRepository<Author> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (!service.Table.Any(x => x.Id == id)) return Results.NotFound();
                    service.Delete(id);
                    return Results.Ok();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
