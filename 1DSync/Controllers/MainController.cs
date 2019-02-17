using _1DSync.Data;
using _1DSync.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DSync.Controllers
{
    class MainController
    {
        private MainView _view;
        private ApplicationDbContext _context;

        public MainController(MainView mainView)
        {
            _view = mainView;
            _context = new ApplicationDbContext();
            _context.Database.Migrate();
        }

        internal object GetDataSource()
        {
            _context.PseudoDynamicEntities.Load();
            return _context.PseudoDynamicEntities.Local.ToBindingList();
        }

        internal void SaveChanges()
        {
            foreach (var item in _context.ChangeTracker.Entries<PseudoDynamicEntity>()
                .Where(s => s.State == EntityState.Modified || s.State == EntityState.Added || s.State == EntityState.Deleted))
            {
                item.Entity.SyncStatus = false;
            }
            foreach (var item in _context.ChangeTracker.Entries<PseudoDynamicEntity>()
                .Where(s => s.State == EntityState.Deleted))
            {
                if (item.Entity.LastModified != null)
                {
                    item.Entity.IsDeleted = true;
                    _context.Entry(item.Entity).State = EntityState.Modified;
                }
            }

            _context.SaveChanges();
        }

        internal void Dev()
        {
            foreach (var item in _context.ChangeTracker.Entries<PseudoDynamicEntity>().Where(s => s.State == EntityState.Deleted))
            {
                item.Entity.IsDeleted = true;
                _context.Entry(item.Entity).State = EntityState.Modified;
                Console.WriteLine(item.Entity.Id);
            }
        }
    }
}
