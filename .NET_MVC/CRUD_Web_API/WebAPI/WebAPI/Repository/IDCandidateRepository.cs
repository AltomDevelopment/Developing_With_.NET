using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IDCandidateRepository
    {
        Task<IEnumerable<Dcandidate>> Search(string fullName);
        Task<IEnumerable<Dcandidate>> GetCandidate();
        Task<Dcandidate> GetCandidateByID(int id);
        Task<Dcandidate> GetCandidateByEmail(string email);
        Task<Dcandidate> AddCandidate(Dcandidate dcandidate);
        Task<Dcandidate> UpdateCandidate(Dcandidate dcandidate);
        Task<Dcandidate> DeleteCandidate(int employeeId);
    }
}