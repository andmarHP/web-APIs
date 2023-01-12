
namespace webAPI.Services
{
    public class HelloWorldServices:IHelloWorldService
    {       
        public string GetHelloWorld()
        {
            return "Hello World";
        }
        public string GetName(string name)
        {
            return "Hello" + name;
        }
        public List<int> GetNumeros()
        {
            var list = new List<int>(){1,2,3,4,5,6,7,8,9,10};
            return list.ToList();
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
        string GetName(string name);
        List<int> GetNumeros();
    }
}