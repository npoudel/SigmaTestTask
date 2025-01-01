using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICandidateService
    {
        void AddOrUpdateCandidate(Candidate candidate);
    }
}
