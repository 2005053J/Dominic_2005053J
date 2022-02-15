using Dominic_2005053J.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominic_2005053J.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Severity> Severitys { get; }
        IGenericRepository<Symptom> Symptoms { get; }
    }
}
