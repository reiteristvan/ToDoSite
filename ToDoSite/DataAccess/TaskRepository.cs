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
            using ( ToDoContext context = new ToDoContext () ) {
                return context.Tasks.ToList ();
            }
        } // End SelectAll

        public IEnumerable<ToDoTask> Select ( Expression<Func<ToDoTask , bool>> filter ) {
            using ( ToDoContext context = new ToDoContext () ) {
                return context.Tasks.Where ( filter ).ToList ();
            }
        } // End Select

        public ToDoTask Insert ( ToDoTask entity ) {
            if ( entity == null )
                throw new ArgumentException ();

            using ( ToDoContext context = new ToDoContext () ) {
                context.Tasks.Add ( entity );
                context.SaveChanges ();
            }

            return entity;
        } // End Insert

        public bool Update ( ToDoTask entity ) {
            if ( entity == null ) {
                return false;
            }

            using ( ToDoContext context = new ToDoContext () ) {
                var task = context.Tasks.SingleOrDefault ( ( item ) => item.Id == entity.Id );

                if ( task == null ) {
                    return false;
                }

                context.Entry ( task ).CurrentValues.SetValues ( entity );
                
                context.SaveChanges ();
            }

            return true;
        } // End Update

        public bool Delete ( object id ) {
            using ( ToDoContext context = new ToDoContext () ) {
                var task = context.Tasks.SingleOrDefault ( ( item ) => item.Id == ( int ) id );

                if ( task == null ) {
                    return false;
                }

                context.Tasks.Remove ( task );
                context.SaveChanges ();
            }

            return true;
        } // End Delete
    }
}