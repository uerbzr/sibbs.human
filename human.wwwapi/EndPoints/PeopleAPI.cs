using human.models;
using human.repository;

namespace human.wwwapi.EndPoints
{
    public static class PeopleApi
    {
        public static void ConfigurePeopleApi(this WebApplication app)
        {
            app.MapGet("/people", GetAll);
            //app.MapGet("/people/{id}", Get);
            app.MapPost("/people", Insert);
            //app.MapPut("/people", Update);
            //app.MapDelete("/people", Delete);
        }
        private static async Task<IResult> Insert(Person person, IDatabaseRepository<Person> service)
        {

            try
            {
                service.Insert(person);
                return Results.Ok();                

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetAll(IDatabaseRepository<Person> repository)

        {
            try
            {

                return Results.Ok(repository.GetAll());

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        /*

        private static async Task<IResult> Get(int id, IDatabaseRepository<Person> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    //var person = service.GetAll().Where(x => x.Id == id).FirstOrDefault();
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        
        private static async Task<IResult> Update(Person person, IDatabaseRepository<Person> service)
        {
            try
            {
                return await Task.Run(() =>
                {
                   // if (service.Update(person)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteUser(int id, IDatabaseRepository<Person> service)
        {
            try
            {
                //if (service.Delete(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        */
    }
}
