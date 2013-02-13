using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoSite.DataAccess;
using ToDoSite.Models;
using WebMatrix.WebData;

namespace ToDoSite.Controllers
{
    [Authorize]
    public class ToDoController : ApiController
    {
        int x = 10;

        public IEnumerable<ToDoTask> Get () {
            x = 11;
            return repository.Select (
                ( task ) => task.UserName == WebSecurity.CurrentUserName );
        } // End Get

        public HttpResponseMessage Post ( ToDoTask task ) {
            var item = repository.Insert ( new ToDoTask () {
                UserName = WebSecurity.CurrentUserName ,
                Date = DateTime.Now ,
                IsCompleted = false ,
                Description = task.Description
            } );

            var response = Request.CreateResponse<ToDoTask> ( HttpStatusCode.OK, item );

            return response;
        } // End Post

        public void Put ( ToDoTask task ) {
            if ( !repository.Update ( task ) ) {
                throw new HttpResponseException ( HttpStatusCode.NotFound );
            }
        } // End Put

        public void Delete ( int id ) {
            var z = x;
            if ( !repository.Delete ( id ) ) {
                throw new HttpResponseException ( HttpStatusCode.NotFound );
            }
        } // End Delete

        // Fields

        static public TaskRepository repository = new TaskRepository ();
    }
}
