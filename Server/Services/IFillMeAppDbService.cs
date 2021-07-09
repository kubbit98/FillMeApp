using FillMeApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillMeApp.Server.Services
{
    public interface IFillMeAppDbService
    {
        public IEnumerable<Party> GetParties();
        public IEnumerable<User> GetUsers();
        public IEnumerable<Survey> GetSurveys();
    }
}
