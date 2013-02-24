using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ToDoSite.Models;

namespace ToDoSite.DataAccess
{
    public class TaskRepository : IRepository<ToDoTask>
    {
        public IEnumerable<ToDoTask> SelectAll () {
            using ( ToDoContext context = new ToDoContext() ) {
                return context.Tasks.ToList();
            }
        } // End SelectAll

        public IEnumerable<ToDoTask> Select ( Expression<Func<ToDoTask , bool>> filter ) {
            using ( ToDoContext context = new ToDoContext() ) {
                return context.Tasks.Where( filter ).ToList();
            }
        } // End Select

        public void Insert ( ToDoTask entity ) {
            using ( ToDoContext context = new ToDoContext() ) {
                context.Tasks.Add( entity );
                context.SaveChanges();
            }
        } // End Insert

        public void Update ( ToDoTask entity ) {
            using ( ToDoContext context = new ToDoContext() ) {
                var task = context.Tasks.SingleOrDefault( ( item ) => item.Id == entity.Id );

                if ( task == null ) {
                    throw new ArgumentException();
                }

                context.Entry( task ).CurrentValues.SetValues( entity );

                context.SaveChanges();
            }
        } // End Update

        public void Delete ( object id ) {
            using ( ToDoContext context = new ToDoContext() ) {
                var task = context.Tasks.SingleOrDefault( ( item ) => item.Id == ( int ) id );

                if ( task == null ) {
                    throw new ArgumentException();
                }

                context.Tasks.Remove( task );
                context.SaveChanges();
            }
        } // End Delete
    }
}