namespace Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User: IdentityUser
    {
        public string Name { set; get; }

        public string Surname { set; get; }

        public string Patronymic { set; get; }

        public List<CarWash> CarWashes { set; get; }
    }
}
