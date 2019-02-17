using _1DSync.Data;
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
            _context.SaveChanges();
        }
    }
}
