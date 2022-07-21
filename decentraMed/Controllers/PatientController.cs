using decentraMed.Models;
using decentraMed.service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace decentraMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController:ControllerBase
    {
        private readonly DataContext _context;

        private HttpClient Client = new HttpClient();

        private Service service = new Service();

        
        
        
        public PatientController(DataContext context)
        {
            _context = context;
            
        }

        //endpoint to add user to the database
        [HttpPost("addUser")]
        public IActionResult AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        [HttpPost("addDiagnostic")]
        public async Task<IActionResult> AddDiagnosticAsync(Diagnosis diagnostic)
        {
            string diagnosticString = JsonSerializer.Serialize(diagnostic);
            var values = new Dictionary<string, string>
              {
                  { "address", diagnostic.Uid },
                  { "url", diagnosticString }
              };

            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync("http://localhost:5002/addRecord", content);



            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var deptObj = JsonSerializer.Deserialize<TokenResponse>(responseString);

                UserTokens userToken = new UserTokens
                {
                    Type = "Diagnostic",
                    Token = Convert.ToInt32(deptObj.tokenID),
                    uid = diagnostic.Uid
                };
                _context.Add(userToken);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("addVisits")]
        public async Task<IActionResult> AddVisitAsync(Visits visit)
        {
            string diagnosticString = JsonSerializer.Serialize(visit);
            var values = new Dictionary<string, string>
              {
                  { "address", visit.Uid},
                  { "url", diagnosticString }
              };

            var content = new FormUrlEncodedContent(values);
            var response = await Client.PostAsync("http://localhost:5002/addRecord", content);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var deptObj = JsonSerializer.Deserialize<TokenResponse>(responseString);

                UserTokens userToken = new UserTokens
                {
                    Type = "Visits",
                    Token = Convert.ToInt32(deptObj.tokenID),
                    uid = visit.Uid
                };
                _context.Add(userToken);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("addAllergy")]
        public async Task<IActionResult> AddAllergyAsync(Allergies allergy)
        {
            string diagnosticString = JsonSerializer.Serialize(allergy);
            var values = new Dictionary<string, string>
              {
                  { "address", allergy.Uid },
                  { "url", diagnosticString }
              };

            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync("http://localhost:5002/addRecord", content);



            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var deptObj = JsonSerializer.Deserialize<TokenResponse>(responseString);

                UserTokens userToken = new UserTokens
                {
                    Type = "Allergies",
                    Token = Convert.ToInt32(deptObj.tokenID),
                    uid = allergy.Uid
                };
                _context.Add(userToken);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
        [HttpPost("addPrescription")]
        public async Task<IActionResult> addPrescription(Presciptions allergy)
        {
            string diagnosticString = JsonSerializer.Serialize(allergy);
            var values = new Dictionary<string, string>
              {
                  { "address", allergy.Uid },
                  { "url", diagnosticString }
              };

            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync("http://localhost:5002/addRecord", content);



            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var deptObj = JsonSerializer.Deserialize<TokenResponse>(responseString);

                UserTokens userToken = new UserTokens
                {
                    Type = "Presciptions",
                    Token = Convert.ToInt32(deptObj.tokenID),
                    uid = allergy.Uid
                };
                _context.Add(userToken);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }


        //FrontEnd APIs

        [HttpGet("getUser")]
        public IActionResult GetUser(String uid)
        {
            var user = _context.User.FirstOrDefault(x => x.idNumber == uid);

            var tokens = _context.userTokens.Where(x => x.uid == user.uid);

            List<Diagnosis> diagnoses = new List<Diagnosis>();
            List<Allergies> allergies= new List<Allergies>();
            List<Visits> visits = new List<Visits>();
            List<Presciptions> presciptions = new List<Presciptions>();





            foreach (UserTokens token in tokens)
            {
                switch (token.Type.ToLower())
                {
                    case "diagnostic":
                        diagnoses.Add(service.GetDiagnosis(token.Token.ToString()).Result);
                        break;
                    case "allergies":
                        allergies.Add(service.GetAllergies(token.Token.ToString()).Result);
                        break;
                    case "visits":
                        visits.Add(service.GetVisits(token.Token.ToString()).Result);
                        break;
                    case "presciptions":
                        presciptions.Add(service.GetPrescriptions(token.Token.ToString()).Result);
                        break;
                    default:
                        break;
                }
            }

            ResponseModel Response = new ResponseModel
            {
                user = user,
                allergies = allergies,
                presciptions = presciptions,
                visits = visits,
                diagnosis = diagnoses,
            };
            return Ok(Response);
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.email.ToLower() == email.ToLower() && x.password == password);
            if(user!= null)
            {
                return Ok();
            }
            return BadRequest();
        }
        




    }
}
