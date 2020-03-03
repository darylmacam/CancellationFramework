using System;

namespace CancellationTkn
{
    public struct MyStruct
    {
        public string Value { get; set; }
    }


    public class TestStruct
    {
        public void Execute()
        {
            //What will be the outcome?
            MyStruct test = default;
            Console.WriteLine($"Value: {test.Value}");
        }
    }
}
