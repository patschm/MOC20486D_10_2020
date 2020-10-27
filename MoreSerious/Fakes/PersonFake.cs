using System;
using System.Threading;
using Bogus;

namespace Fakes
{
    public class PersonFake: Faker<Entities.Person>
    {
        public PersonFake() : base("nl")
        {
            StrictMode(true);
            RuleFor(o => o.ID, f => f.IndexFaker);
            RuleFor(o => o.FirstName, f => f.Name.FirstName());
            RuleFor(o => o.LastName, f => f.Name.LastName());
            RuleFor(o => o.Age, f => f.Random.Int(0, 123));
        }
    }
}
