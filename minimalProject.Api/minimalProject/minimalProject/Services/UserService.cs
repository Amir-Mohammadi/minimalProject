using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using minimalProject.Core;
using minimalProject.Core.Domains.User;
using minimalProject.Models.User;
using Newtonsoft.Json;
using System.Text;

namespace minimalProject.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> AddUser(AddUserInput user, CancellationToken cancellationToken)
        {




            #region send email
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("fskyfall47@gmail.com"));

            email.To.Add(MailboxAddress.Parse(user.Email));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Text) { Text = user.Link };

            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.Connect("smtp.gmail.com", 465, true);
                    smtp.Authenticate("fskyfall47@gmail.com", "vwerhsygucczlqoc");
                    smtp.Send(email);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex); ;
                }
                finally
                {
                    smtp.Disconnect(true);

                }


            }
            #endregion


            #region ip and location
            string accessKey = "6d3030cb7bad443a24fd5925dca9c018";
            string url = "http://api.ipstack.com/";
            string currentIp = "https://ip.seeip.org";

            var ipDetect = "";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(currentIp).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;


                    HttpResponseMessage responseIp = client.GetAsync(url + result + "?access_key=" + accessKey).Result;
                    if (responseIp.IsSuccessStatusCode)
                    {
                        ipDetect = responseIp.Content.ReadAsStringAsync().Result;
                    }
                }


                var ipModel = JsonConvert.DeserializeObject<IpDetect>(ipDetect);
                #endregion


                #region add user process
                var userInput = new User();
                if (ipModel != null)
                {

                    userInput.FirstName = user.FirstName;
                    userInput.LastName = user.LastName;
                    userInput.Email = user.Email;
                    userInput.BirthDate = user.BirthDate;
                    userInput.Link = user.Link;
                    userInput.Ip = ipModel.ip;
                    userInput.Location = ipModel.latitude + " / " + ipModel.longitude + " = " + ipModel.country_name + "," + ipModel.city;
                    await userRepository.AddAsync(entity: userInput, cancellationToken: cancellationToken);
                }
                return userInput;
                #endregion
            }

        }

        public Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsers(IInclude<User> include = null)
        {
            throw new NotImplementedException();
        }


        //public Task<User> GetUserById(int id, CancellationToken cancellationToken)
        //{
        //    return userRepository.GetAsync(x => x.Id == id, cancellationToken);
        //}

        //IInclude<User> userInclude = new Include<User>(query =>
        //{
        //    query = query.Include(x => x.Id);

        //    return query;
        //});

        //public IQueryable<User> GetUsers(IInclude<User> include = null)
        //{
        //    var query = userRepository.GetQuery(include);
        //    return query;
        //}
        //private GetUserInput userModel(User user)
        //{
        //    if (user == null)
        //        return null;
        //    return new GetUserInput()
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        CityName = user.CityName
        //    };

        //}

    }
}
