using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class ComplaintRepository : IComplaintRepository
    {
        private static List<Complaint> _complaints = new List<Complaint>();

        // Implementation of repository methods
        public Task<IEnumerable<Complaint>> GetAllComplaints()
        {
            IEnumerable<Complaint> resenum = _complaints;
            return Task.FromResult(resenum);
        }
        public Task<Complaint> GetComplaintById(int id)
        {
            int i = 0;

            foreach (Complaint comp in _complaints)
            {
                if (comp.Id == _complaints[i].Id)
                {
                    return Task.FromResult(_complaints[i]);
                }
                
                i++;
            }

            return null;
        }


        public Task<IEnumerable<Complaint>> GetComplaintsByDate(DateTime date) // get the CreatedAt Date
        {
            List<Complaint> compList = new List<Complaint>();
            int i = 0;

            foreach (Complaint comp in _complaints)
            {
                if (comp.CreatedAt.Date == date.Date)
                {
                    compList.Add(comp);
                    IEnumerable<Complaint> resenum = compList;
                    return Task.FromResult(resenum);
                }

                i++;
            }

            return null;
        }
        public Task<IEnumerable<Complaint>> SearchComplaintsByName(string name)
        {
            List<Complaint> compList = new List<Complaint>();
            int i = 0;

            foreach (Complaint comp in _complaints)
            {
                if (comp.Complainant.Name == name)
                {
                    compList.Add(comp);
                    IEnumerable<Complaint> resenum = compList;
                    return Task.FromResult(resenum);
                }

                i++;
            }

            return null;
        }
        public Task<Complaint> CreateComplaint(Complaint complaint)
        {
            var comp = complaint;
            _complaints.Add(comp);
            return Task.FromResult(comp);
        }
        public Task<Complaint> UpdateComplaint(Complaint thecomplaint)
        {
            List<Complaint> compList = new List<Complaint>();
            int i = 0;

            foreach (Complaint comp in _complaints)
            {
                if (comp.Id == thecomplaint.Id)
                {
                    _complaints[i] = thecomplaint;
                    return Task.FromResult(_complaints[i]);
                }

                i++;
            }

            return null;
        }
        public Task<Complaint> SetComplaintStatus(int id, ComplaintStatus status)
        {
            //var comp = GetComplaintById(id).Result;
            //comp.Status = status;

            //_complaints.
            // return Task.FromResult(comp);
            List<Complaint> compList = new List<Complaint>();
            int i = 0;

            foreach (Complaint comp in _complaints)
            {
                if (comp.Id == id)
                {
                    _complaints[i].Status = status;
                    return Task.FromResult(_complaints[i]);
                }

                i++;
            }

            return null;
        }
    }
}
