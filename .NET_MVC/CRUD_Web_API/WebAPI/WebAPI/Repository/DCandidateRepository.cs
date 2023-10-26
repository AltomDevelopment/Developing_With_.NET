using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class DCandidateRepository : IDCandidateRepository
    {
        private readonly DonationDBContext donationDBContext;

        public DCandidateRepository(DonationDBContext donationDBContext)
        {
            this.donationDBContext = donationDBContext;
        }
        public async Task<IEnumerable<Dcandidate>> Search(string fullName)
        {
            IQueryable<Dcandidate> query = donationDBContext.DCandidates;

            if (!string.IsNullOrEmpty(fullName))
            {
                query = query.Where(e => e.fullName.Contains(fullName));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Dcandidate>> GetCandidate()
        {
            return await donationDBContext.DCandidates.ToListAsync();
        }
        public async Task<Dcandidate> GetCandidateByID(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("id");
            }
            else
            {
                return await donationDBContext.DCandidates
                .FirstOrDefaultAsync(e => e.id == id);
            }
            
        }
        public async Task<Dcandidate> GetCandidateByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }
            else
            {
                return await donationDBContext.DCandidates
                .FirstOrDefaultAsync(e => e.eMail == email);
            }
                    
            
        }
        public async Task<Dcandidate> AddCandidate(Dcandidate candidate)
        {
            var result = await donationDBContext.DCandidates.AddAsync(candidate);
            await donationDBContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Dcandidate> UpdateCandidate(Dcandidate candidate)
        {
            var result = await donationDBContext.DCandidates
                .FirstOrDefaultAsync(e => e.id == candidate.id);

            if (result != null)
            {
                result.fullName = candidate.fullName;
                result.mobile = candidate.mobile;
                result.eMail = candidate.eMail;
                result.age = candidate.age;
                result.bloodGroup = candidate.bloodGroup;
                result.address = candidate.address;

                await donationDBContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ArgumentNullException("candidate");
            }

        }
        public async Task<Dcandidate> DeleteCandidate(int candidateId)
        {
            var result = await donationDBContext.DCandidates
                .FirstOrDefaultAsync(e => e.id == candidateId);
            if (result != null)
            {
                donationDBContext.DCandidates.Remove(result);
                await donationDBContext.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new ArgumentNullException("candidate");
            }
        }



        

        

       
    }
}