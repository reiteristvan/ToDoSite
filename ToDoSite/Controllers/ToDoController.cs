using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ToDoSite.DataAccess;
using ToDoSite.Models;
using WebMatrix.WebData;

namespace ToDoSite.Controllers
{
    [Authorize]
    public class ToDoController : ApiController
    {
        public IEnumerable<ToDoTask> Get () {
            return repository.Select(
                ( task ) => task.UserName == WebSecurity.CurrentUserName );
        } // End Get

        public HttpResponseMessage Post ( ToDoTask task ) {
            if( task == null ) {
                throw new HttpException( 400 , "Task cannot be null" );
            }

            task.UserName = WebSecurity.CurrentUserName;
            repository.Insert( task );

            return Request.CreateResponse<ToDoTask>( HttpStatusCode.OK , task );
        } // End Post

        public void Put ( ToDoTask task ) {
            try {
                repository.Update( task );
            } catch ( ArgumentException ) {
                throw new HttpException( 404, "The database doesn't contains this item" );
            }
        } // End Put

        public void Delete ( int id ) {
            try {
                repository.Delete( id );
            } catch ( ArgumentException ) {
                throw new HttpException( 404 , "The database doesn't contains this item" );
            }
        } // End Delete

        // Fields

        static public TaskRepository repository = new TaskRepository();
    }
}
