using FillMeApp.Server.Model;
using FillMeApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillMeApp.Server.Services
{
    public class MySQLFillMeAppDbService : IFillMeAppDbService
    {
        private readonly FillMeAppDbContext _context;

        public MySQLFillMeAppDbService(FillMeAppDbContext fillMeAppDbContext)
        {
            _context = fillMeAppDbContext;
        }
        public IEnumerable<Party> GetParties()
        {
            return _context.Parties.ToList();
        }

        public IEnumerable<Survey> GetSurveys()
        {
            return _context.Surveys.ToList();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
