using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using System.Reflection.Emit;
using System.Windows;


namespace WpfApp1
{
    class Complaints
    {
        private static readonly HttpClient client = new HttpClient();

        public Complaints()
        {
            if (client.BaseAddress == null)
                client.BaseAddress = new Uri("https://localhost:44303/"); // Set the base API URL
        }
        public async Task<ActionResult<List<Complaint>>> GetAllComplaints()
        {

            List<Complaint> response = await client.GetFromJsonAsync<List<Complaint>>(client.BaseAddress + "api/Complaints");
            if (response.Count > 0)
            {
                 return response;
            }
            else 
            {
                 return null;
            }

        }
        public async void DisposeClient()
        { 
           client.Dispose();
        }
            public async Task<HttpRequestMessage> PostAllComplaints(List<Complaint>? complaintList)
        {

            var request = await client.PostAsJsonAsync(client.BaseAddress + "api/Complaints/CreateDatabase", complaintList);
           
            
            if (request.IsSuccessStatusCode)
            {
                MessageBox.Show("successfully saved");
                return request.RequestMessage;
            }
            else
            {
                MessageBox.Show("upppsi something get wrong");
                return null;
            }

        }

    }

    public class Complaint
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ComplaintCategory Category { get; set; }
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Person Complainant { get; set; }
    }

    public class Person
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
    }

    public enum ComplaintCategory
    {
        Animals,
        Children,
        Maintenance,
        Parking
    }

    public enum ComplaintStatus
    {
        Pending,
        Active,
        Resolved,
        Cancelled
    }

    public enum ComplaintSearch
    {
        Id,
        Description,
        Location,
        Category,
        Status,
        CreatedAt,
        UpdatedAt,
        Complainant 
    }
}

