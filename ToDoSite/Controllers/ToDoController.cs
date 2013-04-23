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
        public IEnumerable<ToDoTask> Get () 
        {
            return context.Tasks.Where(
                ( task ) => task.UserName == WebSecurity.CurrentUserName );
        } // Get

        public HttpResponseMessage Post ( ToDoTask task ) 
        {
            if( task == null ) 
            {
                throw new HttpException( 400 , "Task cannot be null" );
            }

            task.UserName = WebSecurity.CurrentUserName;
            //task.Date = DateTime.Now;
            context.Tasks.Add( task );
            context.SaveChanges();

            return Request.CreateResponse<ToDoTask>( HttpStatusCode.OK , task );
        } // Post

        public void Put ( ToDoTask task ) {
            var original = context.Tasks
                .SingleOrDefault( ( item ) => item.Id == task.Id );

            if ( original == null )
            {
                throw new HttpException( 404, "The database doesn't contains this item" );
            }

            context.Entry( original ).CurrentValues.SetValues( task );
            context.SaveChanges();
        } // Put

        public void Delete ( int id ) {
            var task = context.Tasks
                .SingleOrDefault( ( item ) => item.Id == ( int ) id );

            if (task == null)
            {
                throw new HttpException(404, "The database doesn't contains this item");
            }

            context.Tasks.Remove( task );
            context.SaveChanges();
        } // Delete

        // Fields

        private ToDoContext context = new ToDoContext();

        // Dispose

        protected override void Dispose(bool disposing)
        {
            context.Dispose();

            base.Dispose(disposing);
        } // Dispose
    }
}
