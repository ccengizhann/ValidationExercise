using FluentValidation.API.Models;
using FluentValidation.Domain.Entities;
using FluentValidation.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        public PerfectAppDbContext _perfectAppDbContext;

        public BankAccountsController(PerfectAppDbContext perfectAppDbContext)
        {
            _perfectAppDbContext = perfectAppDbContext;
        }

        [HttpPost("[action]")]
        public void SetDefaultUserData()
        {
            List<BankAccount> people = new()
            {
                new BankAccount
                 {
                      Id = Guid.Parse("8FEA1F27-3435-924F-4D82-E0B35A53FAE9"),
                     FirstName = "John",
                     LastName = "Doe",
                     PhoneNumber = "123-456-7890",
                     Balance = 1000.0m,
                     CreatedByUserId = "user123",
                     CreatedOn = DateTime.UtcNow,
                     
                 },
                 new BankAccount
                 {
                     Id = Guid.Parse("78A0FB59-98D5-7A3F-55E3-EF529B2E9845"),
                     FirstName = "Jane",
                     LastName = "Smith",
                     PhoneNumber = "987-654-3210",
                     Balance = 1500.0m,
                     CreatedByUserId = "user456",
                    CreatedOn = DateTime.UtcNow,

                 },
                 new BankAccount
                 {
                     Id = Guid.Parse("D4F6A2E3-965A-7A80-529C-7B1346B04C04"),
                     FirstName = "Alice",
                     LastName = "Johnson",
                     PhoneNumber = "555-123-4567",
                     Balance = 2000.0m,
                     CreatedByUserId = "user789",
                    CreatedOn = DateTime.UtcNow,

                 },
                 new BankAccount
                 {
                      Id = Guid.Parse("3422F3C1-B62E-BE13-EC81-B421580819D1"),
                     FirstName = "Bob",
                     LastName = "Williams",
                     PhoneNumber = "789-456-1230",
                     Balance = 500.0m,
                     CreatedByUserId = "userabc",
                     CreatedOn = DateTime.UtcNow,


                 },
                 new BankAccount
                 {
                     Id = Guid.Parse("ED06E6BE-E6AE-35D3-48C8-A585FECD6EC7"),
                     FirstName = "Eva",
                     LastName = "Davis",
                     PhoneNumber = "111-222-3333",
                     Balance = 3000.0m,
                     CreatedByUserId = "userxyz",
                    CreatedOn = DateTime.UtcNow,

                 }
            };
            _perfectAppDbContext.BankAccounts.AddRange(people);
            _perfectAppDbContext.SaveChanges();
        }

        [HttpGet("[action]/{bankAccountId:guid}")]
        public GetBankAccountDataResponseModel GetBankAccountData(Guid bankAccountId)
        {
            var bankAccount = _perfectAppDbContext.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            var response = new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance,
            };

            return response;

        }
    }
}
