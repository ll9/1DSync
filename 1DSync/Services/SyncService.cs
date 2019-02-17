using _1DSync.Data;
using _1DSync.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DSync.Services
{
    class SyncService
    {
        private readonly ApplicationDbContext _context;

        public SyncService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Synchronize()
        {
            var lastModified = _context.PseudoDynamicEntities.Select(e => e.LastModified).Max();
            var dateString = lastModified != null ? lastModified.Value.ToString("o", CultureInfo.InvariantCulture) : "";
            var changes = _context.PseudoDynamicEntities.Where(e => e.SyncStatus == false).ToList();

            var client = new RestClient("https://localhost:44306");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api/PseudoDynamicEntities/synchronize", Method.POST);
            request.AddQueryParameter("lastModified", dateString);

            request.AddJsonBody(changes);

            // execute the request
            var response = client.Execute<List<PseudoDynamicEntity>>(request);
            var content = response.Data; // raw content as string

            foreach (var entity in content)
            {
                entity.SyncStatus = true;
                var localEntity = _context.PseudoDynamicEntities.SingleOrDefault(p => p.Id == entity.Id);

                if (localEntity != null)
                {
                    _context.Entry(localEntity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    _context.PseudoDynamicEntities.Add(entity);
                }
            }
            _context.SaveChanges();
        }
    }
}
