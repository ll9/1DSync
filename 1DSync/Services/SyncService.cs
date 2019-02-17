using _1DSync.Data;
using _1DSync.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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
            var changes = _context.PseudoDynamicEntities.Where(e => e.SyncStatus == false).ToList();
            var json = JsonConvert.SerializeObject(changes);

            var client = new RestClient("http://example.com");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);
            request.AddJsonBody(json);

            // execute the request
            //var response = client.Execute<List<PseudoDynamicEntity>>(request);
            //var content = response.Data; // raw content as string
        }
    }
}
