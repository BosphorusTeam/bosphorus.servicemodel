using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

//TODO: ContractNamespace must be parameterized
[assembly: ContractNamespace("http://schemas.bosphorus.com/DemoModule", ClrNamespace = "Bosphorus.ServiceModel.Hosting.Demo.PocoService")]
namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class DemoService
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }

        public string HelloWorld(string firstName, string lastName)
        {
            return string.Format("Hello {0} {1}", firstName, lastName);
        }

        public string Complex(Customer customer, string name)
        {
            return string.Format("Hello {0}. You sent customer with ID {1}", name, customer.ID);
        }

        public virtual string MultipleInput(IList<Customer> customers)
        {
            throw new ValidationException(123, "Sample validation exception");
            string s = string.Join("-", customers.Select(c => c.ID));
            return s;
        }

        public string GenericInput(Identifiable<DateTime> identifiable)
        {
            return identifiable.Id.ToLongDateString();
        }

        public IEnumerable<Customer> MultipleOutput()
        {
            return new[]
            {
                new Customer{ID="1"},
                new Customer{ID="2"},
                new Customer{ID="3"},
            };
        }

        public void Throw(string name)
        {
            string message = string.Format("Hello {0}", name);
            throw new Exception(message);
        }

        //public int Add(int x, int y)
        //{
        //    return x + y;
        //}

        //public double Distance(Point p1, Point p2)
        //{
        //    double deltaX = p1.X - p2.X;
        //    double deltaY = p1.Y - p2.Y;
        //    return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        //}
    }
}